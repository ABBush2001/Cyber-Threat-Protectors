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

    public GameObject playerHand;
    public GameObject CardToHand;
    public int maxHand;


    // Start is called before the first frame update
    void Start()
    {

        isYourTurn = true;
        yourTurn = 1;
        enemyTurn = 0;
        maxHand = 7;

        playerMaxPoints = 20;
        enemyMaxPoints = 20;
        playerCurPoints = 0;
        enemyCurPoints = 0;
        turnText.text = "Your Turn";

    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurPoints >= playerMaxPoints){
            //play victory screen
            victoryScreen.SetActive(true);
        }
        if(enemyCurPoints >= enemyMaxPoints){
            //play losing screen
            defeatScreen.SetActive(true);
        }

    }

    public void PlayerTurn()
    {
        
        GameObject player = GameObject.Find("Player Card Area");
        GameObject enemy = GameObject.Find("Enemy Play Area");

        



        //DETERMINING BLOCKED ATTACK CARDS
        //temporarily unblock all cards until blocked cards are determined
        for(int i = 0; i < player.transform.childCount; i++)
        {
            if(player.transform.GetChild(i).gameObject.GetComponent<Drag>() == null)
            {
                player.transform.GetChild(i).gameObject.AddComponent<Drag>();
            }
        }

        //search for defense cards in enemy's hand
        for(int i = 0; i < enemy.transform.childCount; i++)
        {
            
            //Anti-Malware
            if(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 0)
            {
                for(int k = 0; k < player.transform.childCount; k++)
                {
                    if(player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 6 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 10)
                    {
                        Destroy(player.transform.GetChild(k).gameObject.GetComponent<Drag>());
                    }
                }
            }

            //Encryption
            if(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 1)
            {
                for(int k = 0; k < player.transform.childCount; k++)
                {
                    if(player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 4 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 5)
                    {
                        Destroy(player.transform.GetChild(k).gameObject.GetComponent<Drag>());
                    }
                }
            }

            //Firewall
            if(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 2)
            {
                for(int k = 0; k < player.transform.childCount; k++)
                {
                    if(player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 9 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 12)
                    {
                        Destroy(player.transform.GetChild(k).gameObject.GetComponent<Drag>());
                    }
                }
            }

            //Security Training
            if(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 3)
            {
                for(int k = 0; k < player.transform.childCount; k++)
                {
                    if(player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 7 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 8)
                    {
                        Destroy(player.transform.GetChild(k).gameObject.GetComponent<Drag>());
                    }
                }
            }
        }
        
    }

    public void PlayerEndTurn()
    {

        //variable to hold player points gained or lost in this turn that will be calculated
        int tempPlayerPoints = 0;
        int tempDamagePoints = 0;

        //grab list of all cards in play area
        GameObject player = GameObject.Find("Player Play Area");
        GameObject enemy = GameObject.Find("Enemy Play Area");

        


        //disable the drag script for any cards in play
        // for(int i = 0; i < player.transform.childCount; i++)
        // {
        //     Destroy(player.transform.GetChild(i).gameObject.GetComponent<Drag>());
        // }

        //look for asset cards, and get their points increase
        for(int i = 0; i < player.transform.childCount; i++)
        {
            if(player.transform.GetChild(i).GetComponent<ThisCard>().thisId >= 14 && player.transform.GetChild(i).GetComponent<ThisCard>().thisId <= 18)
            {
                tempPlayerPoints += 1;
            }
        }

        //look for attack cards, calculate damage
        for(int i = 0; i < player.transform.childCount; i++)
        {
            if(player.transform.GetChild(i).GetComponent<ThisCard>().thisId >= 4 && player.transform.GetChild(i).GetComponent<ThisCard>().thisId <= 13)
            {
                tempDamagePoints += 1;
            }
        }

        //look for defense card in player play, remove appropriate cards in enemy play
        for(int j = 0; j < player.transform.childCount; j++)
        {
            if(player.transform.GetChild(j).GetComponent<ThisCard>().thisId >= 0 && player.transform.GetChild(j).GetComponent<ThisCard>().thisId <= 3)
            {
                //Anti-Malware
                if(player.transform.GetChild(j).GetComponent<ThisCard>().thisId == 0)
                {
                    for(int k = 0; k < enemy.transform.childCount; k++)
                    {
                        if(enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 6 || enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 10 || enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 13)
                        {
                            Destroy(enemy.transform.GetChild(k).gameObject);
                            Destroy(player.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Encryption
                if(player.transform.GetChild(j).GetComponent<ThisCard>().thisId == 1)
                {
                    for(int k = 0; k < enemy.transform.childCount; k++)
                    {
                        if(enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 4 || enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 5)
                        {
                            Destroy(enemy.transform.GetChild(k).gameObject);
                            Destroy(player.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Firewall
                if(player.transform.GetChild(j).GetComponent<ThisCard>().thisId == 2)
                {
                    for(int k = 0; k < enemy.transform.childCount; k++)
                    {
                        if(enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 9 || enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 11 || enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 12)
                        {
                            Destroy(enemy.transform.GetChild(k).gameObject);
                            Destroy(player.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Security Training
                if(player.transform.GetChild(j).GetComponent<ThisCard>().thisId == 3)
                {
                    for(int k = 0; k < enemy.transform.childCount; k++)
                    {
                        if(enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 7 || enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 8)
                        {
                            Destroy(enemy.transform.GetChild(k).gameObject);
                            Destroy(player.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }
            }
        }


        //update player score
        playerCurPoints += tempPlayerPoints;
        enemyCurPoints = enemyCurPoints - tempDamagePoints;
        playerPointText.text = playerCurPoints.ToString();
        enemyPointText.text = enemyCurPoints.ToString();



        //change info for enemy turn
        isYourTurn = false;
        enemyTurn += 1; 
        turnText.text = "Opponent Turn";
        //getScore();
        
        EnemyTurn();
    }

    public void EnemyEndTurn()
    {
        //variable to hold player points gained or lost in this turn that will be calculated
        int tempEnemyPoints = 0;
        int tempDamagePoints = 0;

        //grab list of all cards in play area
        GameObject player = GameObject.Find("Player Play Area");
        GameObject enemy = GameObject.Find("Enemy Play Area");

        //look for asset cards, and get their points increase
        for(int i = 0; i < enemy.transform.childCount; i++)
        {   
            if(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId >= 14 && enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId <= 18)
            {
                Debug.Log(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId);
                tempEnemyPoints += 1;
            }
        }

        //look for attack cards, play them and discard them
        for(int i = 0; i < enemy.transform.childCount; i++)
        {
            if(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId >= 4 && enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId <= 13)
            {
                tempDamagePoints += 1;
            }
        }

       //look for defense card in enemy play, remove appropriate cards in player play
        for(int j = 0; j < enemy.transform.childCount; j++)
        {
            if(enemy.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId >= 0 && enemy.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId <= 3)
            {
                //Anti-Malware
                if(enemy.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 0)
                {
                    for(int k = 0; k < player.transform.childCount; k++)
                    {
                        if(player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 6 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 10 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 13)
                        {
                            Destroy(player.transform.GetChild(k).gameObject);
                            Destroy(enemy.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Encryption
                if(enemy.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 1)
                {
                    for(int k = 0; k < player.transform.childCount; k++)
                    {
                        if(player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 4 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 5)
                        {
                            Destroy(player.transform.GetChild(k).gameObject);
                            Destroy(enemy.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Firewall
                if(enemy.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 2)
                {
                    for(int k = 0; k < player.transform.childCount; k++)
                    {
                        if(player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 9 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 11 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 12)
                        {
                            Destroy(player.transform.GetChild(k).gameObject);
                            Destroy(enemy.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Security Training
                if(enemy.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 3)
                {
                    for(int k = 0; k < player.transform.childCount; k++)
                    {
                        if(player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 7 || player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 8)
                        {
                            Destroy(player.transform.GetChild(k).gameObject);
                            Destroy(enemy.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }
            }
        }

        //update player score
        enemyCurPoints += tempEnemyPoints;
        playerCurPoints = playerCurPoints - tempDamagePoints;
        playerPointText.text = playerCurPoints.ToString();
        enemyPointText.text = enemyCurPoints.ToString();

        isYourTurn = true;
        yourTurn += 1;
        turnText.text = "Your Turn";

        PlayerTurn();
        //StartCoroutine(drawCard());
        if(playerHand.transform.childCount < maxHand){
            
            StartCoroutine(drawCard());
        }

    }

    public void EnemyTurn()
    {
        //call couroutine to execute enemy's move that turn
        StartCoroutine(waitCoroutine());
    }

    IEnumerator waitCoroutine()
    {
        //Debug.Log("Started enemy turn at timestamp: " + Time.time);
        yield return new WaitForSeconds(1);

        //instantiate card from enemy deck to play

        Instantiate(CardToPlay, transform.position, transform.rotation);

        yield return new WaitForSeconds(1);

        //Debug.Log("Ended enemy turn at timestamp : " + Time.time);
        
        EnemyEndTurn();
    }

    /*public void getScore(){
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
        
        }
        playerPointText.text = playerCurPoints.ToString();
        enemyPointText.text = enemyCurPoints.ToString();


    }*/

    IEnumerator drawCard(){
        yield return new WaitForSeconds(1);
		Instantiate(CardToHand, transform.position, transform.rotation);
    }

    // IEnumerator drawCardEnemy(){
    //     yield return new WaitForSeconds(1);
    //     Instantiate(CardToHandEnemy, transform.position, transform.rotation);
    // }

}