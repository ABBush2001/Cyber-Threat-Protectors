using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{

    public GameObject CardToPlay;

    public bool isYourTurn;
    public int yourTurn;
    public int enemyTurn;
    public TextMeshProUGUI turnText;

    public int playerMaxPoints;
    public int playerCurPoints;
    public TextMeshProUGUI playerPointText;

    public int enemyMaxPoints;
    public int enemyCurPoints;
    public TextMeshProUGUI enemyPointText;

    public GameObject playArea;
    public GameObject playAreaEnemy;

    public GameObject victoryScreen;
    public GameObject defeatScreen;

    

    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        enemyTurn = 0;

        playerMaxPoints = 20;
        enemyMaxPoints = 20;
        playerCurPoints = 0;
        enemyCurPoints = 0;
        turnText.text = "Your Turn";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerEndTurn()
    {
        isYourTurn = false;
        enemyTurn += 1; 
        turnText.text = "Opponent Turn";
        getScore();
        
        EnemyTurn();
    }

    public void EnemyEndTurn()
    {
        isYourTurn = true;
        yourTurn += 1;
        turnText.text = "Your Turn";
    }

    public void EnemyTurn()
    {
        StartCoroutine(waitCoroutine());
    }

    IEnumerator waitCoroutine()
    {
        Debug.Log("Started enemy turn at timestamp: " + Time.time);
        yield return new WaitForSeconds(5);

        //instantiate card from enemy deck to play

        Instantiate(CardToPlay, transform.position, transform.rotation);

        Debug.Log("Ended enemy turn at timestamp : " + Time.time);
        
        EnemyEndTurn();
    }

    public void getScore(){
        //int numOfPlayerChildren = playArea.transform.childCount;
        //int numOfEnemyChildren = playAreaEnemy.transform.childCount;
        int pDefense = 0;
        int pAttack = 0;
        int eDefense = 0;
        int eAttack = 0;

        foreach (Transform child in playArea.transform)
        {
            playerCurPoints += child.GetComponent<ThisCard>().cardPoints;
            pAttack += child.GetComponent<ThisCard>().cardDamage;
            pDefense += child.GetComponent<ThisCard>().cardDefense; 
        }
        foreach (Transform child in playAreaEnemy.transform)
        {
            enemyCurPoints += child.GetComponent<ThisCardEnemy>().cardPoints;
            eAttack += child.GetComponent<ThisCardEnemy>().cardDamage;
            eDefense += child.GetComponent<ThisCardEnemy>().cardDefense; 
        }
        if(pDefense >= eAttack){
            pDefense=0;
            eAttack=0;
        }
        if(eDefense >= pAttack){
            eDefense=0;
            pAttack=0;
        }
        playerCurPoints = playerCurPoints - (eAttack - pDefense);
        enemyCurPoints = enemyCurPoints - (pAttack - eDefense);
        if(playerCurPoints >= playerMaxPoints){
            //play victory screen
            victoryScreen.SetActive(true);
        }
        if(enemyCurPoints >= enemyMaxPoints){
            //play losing screen
            defeatScreen.SetActive(true);
        }
        Debug.Log("current points: " + playerCurPoints);
        playerPointText.text = playerCurPoints.ToString();
        enemyPointText.text = enemyCurPoints.ToString();


    }

}