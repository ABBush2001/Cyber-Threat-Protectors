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
        int defenseFound = 0;

        //variable to hold player points gained or lost in this turn that will be calculated
        int tempPlayerPoints = 0;

        //grab list of all cards in play area
        GameObject player = GameObject.Find("Player Play Area");

        //look for asset cards, and get their points increase
        for(int i = 0; i < player.transform.childCount; i++)
        {
            if(player.transform.GetChild(i).GetComponent<ThisCard>().thisId == 2)
            {
                tempPlayerPoints += 1;
            }
        }

        //look for attack cards, play them and discard them
        for(int i = 0; i < player.transform.childCount; i++)
        {
            if(player.transform.GetChild(i).GetComponent<ThisCard>().thisId == 1)
            {
                //look for asset card in enemy hand - look for defense card first and delete that if there - else, destroy asset then delete attack card, otherwise keep attack card in play
                GameObject enemy = GameObject.Find("Enemy Play Area");
                for(int j = 0; j < enemy.transform.childCount; j++)
                {
                    if(enemy.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 0)
                    {
                        enemy.transform.GetChild(j).parent = null; //delete enemy defense card
                        player.transform.GetChild(i).parent = null; //delete player attack card
                        Debug.Log("Enemy Defense Deleted");
                        defenseFound = 1;
                    }
                }
                    
                if(defenseFound == 0)
                {
                    for(int k = 0; k < enemy.transform.childCount; k++)
                    {
                        if(enemy.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 2)
                        {
                            enemy.transform.GetChild(k).parent = null; //delete enemy asset card
                            player.transform.GetChild(i).parent = null; //delete player attack card
                            Debug.Log("Enemy Defense Deleted");
                        }
                    }
                }
            }
        }

        //update player score
        playerCurPoints += tempPlayerPoints;
        playerPointText.text = playerCurPoints.ToString();



        //change info for enemy turn
        isYourTurn = false;
        enemyTurn += 1; 
        turnText.text = "Opponent Turn";
        EnemyTurn();
    }

    public void EnemyEndTurn()
    {
        int defenseFound = 0;

        //variable to hold player points gained or lost in this turn that will be calculated
        int tempEnemyPoints = 0;

        //grab list of all cards in play area
        GameObject enemy = GameObject.Find("Enemy Play Area");

        //look for asset cards, and get their points increase
        for(int i = 0; i < enemy.transform.childCount; i++)
        {
            if(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 2)
            {
                tempEnemyPoints += 1;
            }
        }

        //look for attack cards, play them and discard them
        for(int i = 0; i < enemy.transform.childCount; i++)
        {
            if(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 1)
            {
                //look for asset card in player hand - look for defense card first and delete that if there - else, destroy asset then delete attack card, otherwise keep attack card in play
                GameObject player = GameObject.Find("Player Play Area");
                for(int j = 0; j < player.transform.childCount; j++)
                {
                    if(player.transform.GetChild(j).GetComponent<ThisCard>().thisId == 0)
                    {
                        player.transform.GetChild(j).parent = null; //delete player defense card
                        enemy.transform.GetChild(i).parent = null; //delete enemy attack card
                        Debug.Log("Player Defense Deleted");
                        defenseFound = 1;
                    }

                }

                if(defenseFound == 0)
                {
                    for(int k = 0; k < player.transform.childCount; k++)
                    {
                        if(player.transform.GetChild(k).GetComponent<ThisCard>().thisId == 2)
                        {
                            player.transform.GetChild(k).parent = null; //delete player asset card
                            enemy.transform.GetChild(i).parent = null; //delete enemy attack card
                            Debug.Log("Player Asset Deleted");
                        }
                    }
                }
            }
        }

        //update player score
        enemyCurPoints += tempEnemyPoints;
        enemyPointText.text = enemyCurPoints.ToString();

        isYourTurn = true;
        yourTurn += 1;
        turnText.text = "Your Turn";
    }

    public void EnemyTurn()
    {
        //call couroutine to execute enemy's move that turn
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