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
    public Text playerPointText;

    public int enemyMaxPoints;
    public int enemyCurPoints;
    public Text enemyPointText;

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

}