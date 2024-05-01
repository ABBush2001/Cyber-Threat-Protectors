using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using System;

public class TurnSystem : MonoBehaviour
{
    private int turnTracker;

    public int cardsPlayed;

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

    public GameObject playerCardArea;
    public GameObject playerAttackArea;
    public GameObject playerAssetArea;
    public GameObject playerDefenseArea;
    public GameObject enemyAttackArea;
    public GameObject enemyAssetArea;
    public GameObject enemyDefenseArea;

    public GameObject victoryScreen;
    public GameObject defeatScreen;

    public GameObject playerHand;
    public GameObject CardToHand;
    public int maxHand;

    public Button button;

    bool encryp = false;
    bool malw = false;
    bool fire = false;

    bool doublee = false;
    bool doublem = false;
    bool doublef = false;

    int turn = 1;
    int enemyHandCount;

    public string cardPref;


    // Start is called before the first frame update
    void Start()
    {
        cardsPlayed = 0;
        turnTracker = 1;
        isYourTurn = true;
        enemyHandCount = 4;
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
        LimitDoubles();
        LimitPlayerAttackCard();


        if(playerCurPoints >= playerMaxPoints){
            //play victory screen
            victoryScreen.SetActive(true);
        }
        if(enemyCurPoints >= enemyMaxPoints){
            //play losing screen
            defeatScreen.SetActive(true);
        }

    }

    public int getTurnTracker()
    {
        return turnTracker;
    }

    public void PlayerTurn()
    {

        //DETERMINING BLOCKED ATTACK CARDS
        
        //if enemy has a defense card in play that blocks certain attack cards, disable their drag
        //temporarily unblock all cards (except special attack cards) until blocked cards are determined
        for(int i = 0; i < playerAttackArea.transform.childCount; i++)
        {
            if(playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId != 5 && playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId != 11 && playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 13)
            {
                playerAttackArea.transform.GetChild(i).gameObject.GetComponent<ThisCard>().isBlocked = false;
            }

        }

        //search for defense cards in enemy's hand
        for(int i = 0; i < enemyDefenseArea.transform.childCount; i++)
        {
            
            //Anti-Malware
            if(enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 0)
            {
                for(int k = 0; k < playerAttackArea.transform.childCount; k++)
                {
                    if(playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 6 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 10)
                    {
                        playerAttackArea.transform.GetChild(k).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                }
            }

            //Encryption
            if(enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 1)
            {
                for(int k = 0; k < playerAttackArea.transform.childCount; k++)
                {
                    if(playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 4 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 5)
                    {
                        playerAttackArea.transform.GetChild(k).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                }
            }

            //Firewall
            if(enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 2)
            {
                for(int k = 0; k < playerAttackArea.transform.childCount; k++)
                {
                    if(playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 9 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 12)
                    {
                        playerAttackArea.transform.GetChild(k).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                }
            }

            //Security Training
            if(enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 3)
            {
                for(int k = 0; k < playerAttackArea.transform.childCount; k++)
                {
                    if(playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 7 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 8)
                    {
                        playerAttackArea.transform.GetChild(k).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                }
            }
        }


    }


    public void LimitDoubles()
    {
        //method called every turn that checks if a special attack card is in play and, if so, to block other cards upon it being played

       
        //check if special attack card is in play; if so, disable drag on any instance of the card in hand
        for(int i = 0; i < playerAttackArea.transform.childCount; i++)
        {
            //Weak Encryption Key
            if(playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 5)
            {
                Debug.Log("Encryp found in play");
                for(int j = 0; j < playerAttackArea.transform.childCount; j++)
                {
                    if(playerAttackArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 5)
                    {
                        doublee = true;
                        playerAttackArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                }
            }

            //Anti-Malware
            if (playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 13)
            {
                Debug.Log("Anti-Mal found in play");
                for (int j = 0; j < playerAttackArea.transform.childCount; j++)
                {
                    if (playerAttackArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 13)
                    {
                        doublem = true;
                        playerAttackArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                }
            }

            //Firewall Rules
            if (playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 11)
            {
                Debug.Log("Firewall Rules found in play");
                for (int j = 0; j < playerAttackArea.transform.childCount; j++)
                {
                    if (playerAttackArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 11)
                    {
                        doublef = true;
                        playerAttackArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                }
            }
        }
    }

    public void LimitPlayerAttackCard()
    {

        //disable all special cards in hand to start, if the associated defense card is not in play
        for(int i = 0; i < playerCardArea.transform.childCount; i++)
        {
            if(playerCardArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 5 || playerCardArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 11 || playerCardArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 13)
            {
                playerCardArea.transform.GetChild(i).GetComponent<ThisCard>().isBlocked = true;
            }
        }

        if (encryp == false)
        {
            for (int i = 0; i < playerAttackArea.transform.childCount; i++)
            {
                if (playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 5)
                {
                    playerAttackArea.transform.GetChild(i).gameObject.GetComponent<ThisCard>().isBlocked = true;
                }
            }
        }

        if(malw == false)
        {
            for(int i = 0; i < playerAttackArea.transform.childCount; i++)
            {
                if(playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 13)
                {
                    playerAttackArea.transform.GetChild(i).gameObject.GetComponent<ThisCard>().isBlocked = true;
                }
            }
        }
        
        if(fire == false)
        {
            for(int i = 0; i < playerAttackArea.transform.childCount; i++)
            {
                if(playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 11)
                {
                    playerAttackArea.transform.GetChild(i).gameObject.GetComponent<ThisCard>().isBlocked = true;
                }
            }
        }

        //check for appropriate defense cards
        for(int i = 0; i < enemyDefenseArea.transform.childCount; i++)
        {
            //Anti-Malware
            if (enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 0)
            {
                //in play
                for (int j = 0; j < playerAttackArea.transform.childCount; j++)
                {
                    if (playerAttackArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 13)
                    {
                        if(doublem == false)
                        {
                            malw = true;
                            playerAttackArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = false;
                        }

                    }
                }
                //in hand
                for (int j = 0; j < playerCardArea.transform.childCount; j++)
                {
                    //trojan horse and i love you virus
                    if (playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 6 || playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 10)
                    {
                        playerCardArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                    //malware rules not updated
                    if(playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 13)
                    {
                        playerCardArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = false;
                    }
                }
            }
            

            //Encryption
            if (enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 1)
            {
                //in play
                for (int j = 0; j < playerAttackArea.transform.childCount; j++)
                {
                    if (playerAttackArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 5)
                    {
                        if(doublee == false)
                        {
                            encryp = true;
                            playerAttackArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = false;
                        }

                    }
                }
                //in hand
                for (int j = 0; j < playerCardArea.transform.childCount; j++)
                {
                    //wireless sniffing
                    if (playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 4)
                    {
                        playerCardArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                    //weak encryption key
                    if(playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 5)
                    {
                        playerCardArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = false;
                    }
                }

            }
            
            
            //Firewall
            if (enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 2)
            {
                //in play
                for (int j = 0; j < playerAttackArea.transform.childCount; j++)
                {
                    //firewall rules not updated
                    if (playerAttackArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 11)
                    {
                        if(doublef == false)
                        {
                            fire = true;
                            playerAttackArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = false;
                        }
                        
                    }
                    
                }
                //in hand
                for(int j = 0; j < playerCardArea.transform.childCount; j++)
                {
                    //ip spoofing and denial of service
                    if (playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 9 || playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 12)
                    {
                        playerCardArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                    //firewall rules not updated
                    if(playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 11)
                    {
                        playerCardArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = false;
                    }
                }
            }

            //Security Training
            if(enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 3)
            {
                //in hand
                for (int j = 0; j < playerCardArea.transform.childCount; j++)
                {
                    //phishing and password cracked
                    if (playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 7 || playerCardArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 8)
                    {
                        playerCardArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = true;
                    }
                }
            }

            
        }
    }

    public void PlayerEndTurn()
    {
        //go through player hand and destroy remaining cards
        for(int i = 0; i < playerCardArea.transform.childCount; i++)
        {
            Destroy(playerCardArea.transform.GetChild(i).gameObject);
        }

        //variable to hold player points gained or lost in this turn that will be calculated
        int tempPlayerPoints = 0;
        int tempDamagePoints = 0;

        
        //disable the drag script for any cards in play
        // for(int i = 0; i < player.transform.childCount; i++)
        // {
        //     Destroy(player.transform.GetChild(i).gameObject.GetComponent<Drag>());
        // }

        //look for asset cards, and get their points increase
        for(int i = 0; i < playerAssetArea.transform.childCount; i++)
        {
            if(playerAssetArea.transform.GetChild(i).GetComponent<ThisCard>().thisId >= 14 && playerAssetArea.transform.GetChild(i).GetComponent<ThisCard>().thisId <= 18)
            {
                tempPlayerPoints += 1;
            }
        }

        //look for special attack cards, calculate damage and removed associated cards
        for(int i = 0; i < playerAttackArea.transform.childCount; i++)
        {
            //Weak Encryption
            if(playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 5)
            {
                for(int j = 0; j < enemyDefenseArea.transform.childCount; j++)
                {
                    if(enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 1)
                    {
                        Destroy(enemyDefenseArea.transform.GetChild(j).gameObject);
                        Destroy(playerAttackArea.transform.GetChild(i).gameObject);
                        encryp = false;
                    }
                }
            }

            //Firewall Rules
            if(playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 11)
            {
                for(int j = 0; j < enemyDefenseArea.transform.childCount; j++)
                {
                    if(enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 2)
                    {
                        Destroy(enemyDefenseArea.transform.GetChild(j).gameObject);
                        Destroy(playerAttackArea.transform.GetChild(i).gameObject);
                        fire = false;
                    }
                }
            }

            //Anti-Malware
            if(playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == 13)
            {
                for(int j = 0; j < enemyDefenseArea.transform.childCount; j++)
                {
                    if(enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 0)
                    {
                        Destroy(enemyDefenseArea.transform.GetChild(j).gameObject);
                        Destroy(playerAttackArea.transform.GetChild(i).gameObject);
                        malw = false;
                    }
                }
            }
        }

        //look for attack cards, calculate damage
        for(int i = 0; i < playerAttackArea.transform.childCount; i++)
        {
            if(playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId >= 4 && playerAttackArea.transform.GetChild(i).GetComponent<ThisCard>().thisId <= 13)
            {
                tempDamagePoints += 1;
            }
        }

        //look for defense card in player play, remove appropriate cards in enemy play
        for(int j = 0; j < playerDefenseArea.transform.childCount; j++)
        {
            if(playerDefenseArea.transform.GetChild(j).GetComponent<ThisCard>().thisId >= 0 && playerDefenseArea.transform.GetChild(j).GetComponent<ThisCard>().thisId <= 3)
            {
                //Anti-Malware
                if(playerDefenseArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 0)
                {
                    for(int k = 0; k < enemyAttackArea.transform.childCount; k++)
                    {
                        if(enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 6 || enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 10 || enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 13)
                        {
                            Destroy(enemyAttackArea.transform.GetChild(k).gameObject);
                            Destroy(playerDefenseArea.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Encryption
                if(playerDefenseArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 1)
                {
                    for(int k = 0; k < enemyAttackArea.transform.childCount; k++)
                    {
                        if(enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 4 || enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 5)
                        {
                            Destroy(enemyAttackArea.transform.GetChild(k).gameObject);
                            Destroy(playerDefenseArea.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Firewall
                if(playerDefenseArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 2)
                {
                    for(int k = 0; k < enemyAttackArea.transform.childCount; k++)
                    {
                        if(enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 9 || enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 11 || enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 12)
                        {
                            Destroy(enemyAttackArea.transform.GetChild(k).gameObject);
                            Destroy(playerDefenseArea.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Security Training
                if(playerDefenseArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 3)
                {
                    for(int k = 0; k < enemyAttackArea.transform.childCount; k++)
                    {
                        if(enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 7 || enemyAttackArea.transform.GetChild(k).GetComponent<ThisCardEnemy>().thisId == 8)
                        {
                            Destroy(enemyAttackArea.transform.GetChild(k).gameObject);
                            Destroy(playerDefenseArea.transform.GetChild(j).gameObject);
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

        //update turn counter and reset card count
        turnTracker++;
        cardsPlayed = 0;

        //change info for enemy turn
        isYourTurn = false;
        enemyTurn += 1; 
        turnText.text = "Opponent Turn";
        //getScore();
        enemyHandCount = 4;

        EnemyTurn();
    }

    IEnumerator EnemyEndTurn()
    {
        yield return new WaitForSeconds(1);

        //variable to hold player points gained or lost in this turn that will be calculated
        int tempEnemyPoints = 0;
        int tempDamagePoints = 0;

        //grab list of all cards in play area
        //GameObject player = GameObject.Find("Player Play Area");
        //GameObject enemy = GameObject.Find("Enemy Play Area");

        //look for asset cards, and get their points increase
        for(int i = 0; i < enemyAssetArea.transform.childCount; i++)
        {   
            if(enemyAssetArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId >= 14 && enemyAssetArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId <= 18)
            {
                //Debug.Log(enemy.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId);
                tempEnemyPoints += 1;
            }
        }

        //look for attack cards, play them and discard them
        for(int i = 0; i < enemyAttackArea.transform.childCount; i++)
        {
            //if firewall rules not updated in play, look for firewall in player hand and delete it
            if(enemyAttackArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 11)
            {
                Debug.Log("Firewall rules not updated found in enemy!");

                for (int k = 0; k < playerDefenseArea.transform.childCount; k++)
                {
                    if(playerDefenseArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 2)
                    {
                        Destroy(playerDefenseArea.transform.GetChild(k).gameObject);
                        Destroy(enemyAttackArea.transform.GetChild(i).gameObject);
                        break;
                    }
                }
            }

            //if weak encryption key in play, look for encryption in player hand and delete it
            if (enemyAttackArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 5)
            {
                Debug.Log("weak encryption key found in enemy!");

                for (int k = 0; k < playerDefenseArea.transform.childCount; k++)
                {
                    if (playerDefenseArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 1)
                    {
                        Destroy(playerDefenseArea.transform.GetChild(k).gameObject);
                        Destroy(enemyAttackArea.transform.GetChild(i).gameObject);
                        break;
                    }
                }
            }

            if (enemyAttackArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId >= 4 && enemyAttackArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId <= 13)
            {
                tempDamagePoints += 1;
            }
        }

       //look for defense card in enemy play, remove appropriate cards in player play
        for(int j = 0; j < enemyDefenseArea.transform.childCount; j++)
        {
            if(enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId >= 0 && enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId <= 3)
            {
                //Anti-Malware
                if(enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 0)
                {
                    for(int k = 0; k < playerAttackArea.transform.childCount; k++)
                    {
                        if(playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 6 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 10 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 13)
                        {
                            Destroy(playerAttackArea.transform.GetChild(k).gameObject);
                            Destroy(enemyDefenseArea.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Encryption
                if(enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 1)
                {
                    for(int k = 0; k < playerAttackArea.transform.childCount; k++)
                    {
                        if(playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 4 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 5)
                        {
                            Destroy(playerAttackArea.transform.GetChild(k).gameObject);
                            Destroy(enemyDefenseArea.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Firewall
                if(enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 2)
                {
                    for(int k = 0; k < playerAttackArea.transform.childCount; k++)
                    {
                        if(playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 9 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 11 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 12)
                        {
                            Destroy(playerAttackArea.transform.GetChild(k).gameObject);
                            Destroy(enemyDefenseArea.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }

                //Security Training
                if(enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 3)
                {
                    for(int k = 0; k < playerAttackArea.transform.childCount; k++)
                    {
                        if(playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 7 || playerAttackArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 8)
                        {
                            Destroy(playerAttackArea.transform.GetChild(k).gameObject);
                            Destroy(enemyDefenseArea.transform.GetChild(j).gameObject);
                            break;
                        }
                    }
                }
            }
        }

        //look for special cards in enemy play, remove appropriate cards in player play
        for(int j = 0; j < enemyAttackArea.transform.childCount; j++)
        {
            //if hardware failure found
            if(enemyAttackArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 19)
            {
                for(int k = 0; k < playerAssetArea.transform.childCount; k++)
                {
                    if(playerAssetArea.transform.GetChild(k).GetComponent<ThisCard>().thisId >= 14 && playerAssetArea.transform.GetChild(k).GetComponent<ThisCard>().thisId <= 18)
                    {
                        Destroy(playerAssetArea.transform.GetChild(k).gameObject);
                        Destroy(enemyAttackArea.transform.GetChild(j).gameObject);
                        break;
                    }
                }
            }

            bool secTrainFound = false;

            //if forgot to patch found
            if(enemyAttackArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 20)
            {
                Debug.Log("Forgot to patch found!");

                for (int k = 0; k < playerDefenseArea.transform.childCount; k++)
                {
                    if (playerDefenseArea.transform.GetChild(k).GetComponent<ThisCard>().thisId == 3)
                    {
                        secTrainFound = true;
                        Destroy(playerDefenseArea.transform.GetChild(k).gameObject);
                        Destroy(enemyAttackArea.transform.GetChild(j).gameObject);
                        break;
                    }
                }

                if(secTrainFound == false)
                {
                    Debug.Log("Security Training not found!");

                    //if security training not found, grab up to two random cards from player's hand and destroy them
                    if(playerCardArea.transform.childCount >= 2)
                    {
                        yield return new WaitForSeconds(3);

                        int position = UnityEngine.Random.Range(0, playerCardArea.transform.childCount);
                        Destroy(playerCardArea.transform.GetChild(position).gameObject);
                        position = UnityEngine.Random.Range(0, playerCardArea.transform.childCount);
                        Destroy(playerCardArea.transform.GetChild(position).gameObject);

                        Destroy(enemyAttackArea.transform.GetChild(j).gameObject);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(3);
                    Destroy(enemyAttackArea.transform.GetChild(j).gameObject);
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

        doublee = false;
        doublem = false;
        doublef = false;

        PlayerTurn();

         //Debug.Log("number of cards in hand: " + playerHand.transform.childCount);
         //StartCoroutine(drawCard());
        if(playerCardArea.transform.childCount < maxHand){
            button.enabled = false;
            StartCoroutine(drawCard());
        }

    }

    public void EnemyTurn()
    {
        //call couroutine to execute enemy's move that turn
        //StartCoroutine(waitCoroutine());

        /*Check if card is valid, then if so check if it matches pref. If not, go to next card. 
         * If none match pref, do a second loop and find the first card that is valid and play it*/

        /*New code (4/25/2024): AI should continue this process until the max number of cards are in play*/

        bool validCard = true;

        //foundCardPref = false;

        /*IDEA: See how many cards are in hand - play random number of cards from hand*/
        for(int i = 0; i < enemyHandCount; i++)
        {
            //grab first card from deck, pass it into checkDefense

            GameObject temp = new GameObject();
            temp.AddComponent<ThisCardEnemy>();
            try
            {
                temp.GetComponent<ThisCardEnemy>().SetIDAndType(Deck.staticEnemyDeck[i].id, Deck.staticEnemyDeck[i].cardType);
            }
            catch(Exception e)
            {
                Debug.Log("Index Out of Bounds Exception");
            }

            //check if card we are checking is attack, defense or asset

            //defense
            if (temp.GetComponent<ThisCardEnemy>().thisId >= 0 && temp.GetComponent<ThisCardEnemy>().thisId <= 3)
            {
                bool foundDef = false;

                //check that the same defense card is not already in play
                for(int a = 0; a < enemyDefenseArea.transform.childCount; a++)
                {
                    if (temp.GetComponent<ThisCardEnemy>().thisId == enemyDefenseArea.transform.GetChild(a).GetComponent<ThisCardEnemy>().thisId)
                    {
                        Debug.Log("Enemy tried to play defense card but was unable!");
                        foundDef = true;
                        break;
                    }
                }
                if(foundDef == false)
                {
                    validCard = enemyDefenseArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
                }
            }
            //attack
            else if (temp.GetComponent<ThisCardEnemy>().thisId >= 4 && temp.GetComponent<ThisCardEnemy>().thisId <= 13)
            {
                bool excepFound = false;

                //special attack cards
                for(int a = 0; a < playerDefenseArea.transform.childCount; a++)
                {
                    //weak encryption key
                    if (temp.GetComponent<ThisCardEnemy>().thisId == 5 && playerDefenseArea.GetComponentInChildren<ThisCard>().thisId != 1)
                    {
                        Debug.Log("Tried to play weak encryption key but was unable!");
                        excepFound = true;
                        break;
                    }
                    //firewall rules
                    else if (temp.GetComponent<ThisCardEnemy>().thisId == 11 && playerDefenseArea.GetComponentInChildren<ThisCard>().thisId != 2)
                    {
                        Debug.Log("Tried to play firewall rules but was unable!");
                        excepFound = true;
                        break;
                    }
                    //anti-malware
                    else if (temp.GetComponent<ThisCardEnemy>().thisId == 13 && playerDefenseArea.GetComponentInChildren<ThisCard>().thisId != 0)
                    {
                        Debug.Log("Tried to play anti-malware but was unable!");
                        excepFound = true;
                        break;
                    }
                }

                if (excepFound == false)
                {
                    validCard = enemyAttackArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
                }
            }
            //asset
            else if (temp.GetComponent<ThisCardEnemy>().thisId >= 14 && temp.GetComponent<ThisCardEnemy>().thisId <= 18)
            {
                validCard = enemyAssetArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
            }
            //special
            else
            {
                bool specialCardUnable = false;

                //for special cards, need to check if special conditions are met
                //hardware failure
                if (temp.GetComponent<ThisCardEnemy>().thisId == 19 && playerAssetArea.transform.childCount == 0)
                {
                    Debug.Log("Enemy tried to play Hardware Failure but was unable!");
                    specialCardUnable = true;
                }
                //forgot to patch
                for(int a = 0; a < playerDefenseArea.transform.childCount; a++)
                {
                    if (temp.GetComponent<ThisCardEnemy>().thisId == 20 && (playerDefenseArea.transform.GetChild(a).GetComponent<ThisCard>().thisId != 3 && playerCardArea.gameObject.transform.childCount < 2))
                    {
                        Debug.Log("Enemy tried to play Forgot to Patch but was unable!");
                        specialCardUnable = true;
                        break;
                    }
                }
                
                if(specialCardUnable == false)
                {
                    validCard = enemyAttackArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
                }
            }

            if (validCard)
            {
                //swap card to index 0 in deck, then instantiate
                if (string.Equals(temp.GetComponent<ThisCardEnemy>().thisId, Deck.staticEnemyDeck[0].id))
                {
                    Instantiate(CardToPlay, transform.position, transform.rotation);
                }
                else
                {
                    Card swap = Deck.staticEnemyDeck[0];
                    Deck.staticEnemyDeck[0] = Deck.staticEnemyDeck[i];
                    Deck.staticEnemyDeck[i] = swap;
                    Instantiate(CardToPlay, transform.position, transform.rotation);
                    enemyHandCount--;
                }
            }
        }

        if(validCard == false)
        {
            Debug.Log("No valid card found to play");
        }

        StartCoroutine(EnemyEndTurn());
    }

    IEnumerator drawCard(){
        int curCount = playerCardArea.transform.childCount;
        Debug.Log("current count is " + curCount);
        yield return new WaitForSeconds(1);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;         //card anim
        UnityEngine.Cursor.visible = false;                          //card anim

        
        for (int i = curCount; i < 5; i++)
        {
            GameObject card = Instantiate(CardToHand, transform.position, transform.rotation);
            LeanTween.scale(card, new Vector3(2, 2, 2), 0.001f);
            yield return new WaitForSeconds(1);
        }
        
        button.enabled = true;

        UnityEngine.Cursor.lockState = CursorLockMode.None;         //card anim
        UnityEngine.Cursor.visible = true;                          //card anim
    }

    IEnumerator waitAMin()
    {
        yield return new WaitForSeconds(5);
    }

    // IEnumerator drawCardEnemy(){
    //     yield return new WaitForSeconds(1);
    //     Instantiate(CardToHandEnemy, transform.position, transform.rotation);
    // }

}