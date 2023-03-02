using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.WindowsRuntime;

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
    
    bool encryp = false;
    bool malw = false;
    bool fire = false;

    bool doublee = false;
    bool doublem = false;
    bool doublef = false;

    int turn = 1;

    public string cardPref;


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
            }
            

            //Weak Encryption Key
            if (enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 1)
            {
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
            }
            
            
            //Firewall Rules
            if (enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 2)
            {
                for (int j = 0; j < playerAttackArea.transform.childCount; j++)
                {
                    if (playerAttackArea.transform.GetChild(j).GetComponent<ThisCard>().thisId == 11)
                    {
                        if(doublef == false)
                        {
                            fire = true;
                            playerAttackArea.transform.GetChild(j).gameObject.GetComponent<ThisCard>().isBlocked = false;
                        }
                        
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



        //change info for enemy turn
        isYourTurn = false;
        enemyTurn += 1; 
        turnText.text = "Opponent Turn";
        //getScore();
        
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
                    if(playerAssetArea.transform.childCount + playerAttackArea.transform.childCount + playerDefenseArea.transform.childCount >= 2)
                    {
                        //destroy an asset and attack card
                        Destroy(playerAssetArea.transform.GetChild(0).gameObject);   
                        Destroy(playerAttackArea.transform.GetChild(1).gameObject);

                        Destroy(enemyAttackArea.transform.GetChild(j).gameObject);
                        break;
                    }
                    else if(playerAssetArea.transform.childCount + playerAttackArea.transform.childCount + playerDefenseArea.transform.childCount == 1)
                    {
                        Destroy(playerAssetArea.transform.GetChild(0));
                        Destroy(enemyAttackArea.transform.GetChild(j).gameObject);
                        break;
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

        doublee = false;
        doublem = false;
        doublef = false;

        PlayerTurn();

         //Debug.Log("number of cards in hand: " + playerHand.transform.childCount);
         //StartCoroutine(drawCard());
        if(playerAssetArea.transform.childCount + playerAttackArea.transform.childCount + playerDefenseArea.transform.childCount < maxHand){
            
            StartCoroutine(drawCard());
        }

    }

    public void EnemyTurn()
    {
        //call couroutine to execute enemy's move that turn
        //StartCoroutine(waitCoroutine());

        /*Check if card is valid, then if so check if it matches pref. If not, go to next card. 
         * If none match pref, do a second loop and find the first card that is valid and play it*/

        bool foundCardPref;
        bool validCard = true;
        int cardCount;

        foundCardPref = false;
        cardCount = 0;

        

        while (cardCount < 5 && foundCardPref == false)
        {
            //grab first card from deck, pass it into checkDefense
       
            GameObject temp = new GameObject();
            temp.AddComponent<ThisCardEnemy>();
            temp.GetComponent<ThisCardEnemy>().SetIDAndType(Deck.staticEnemyDeck[cardCount].id, Deck.staticEnemyDeck[cardCount].cardType);
            //check if card we are checking is attack, defense or asset

            //defense
            if(temp.GetComponent<ThisCardEnemy>().thisId >= 0 && temp.GetComponent<ThisCardEnemy>().thisId <= 3)
            {
                validCard = enemyDefenseArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
            }
            //attack
            else if (temp.GetComponent<ThisCardEnemy>().thisId >= 4 && temp.GetComponent<ThisCardEnemy>().thisId <= 13)
            {
                validCard = enemyAttackArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
            }
            //asset
            else if (temp.GetComponent<ThisCardEnemy>().thisId >= 14 && temp.GetComponent<ThisCardEnemy>().thisId <= 18)
            {
                validCard = enemyAssetArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
            }
            //special
            else
            {
                validCard = enemyAttackArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
            }
            //validCard = playAreaEnemy.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
            //if card is valid, check preference - else, continue
            if(validCard)
            {
                if (string.Equals(temp.GetComponent<ThisCardEnemy>().cardTypeID, cardPref))
                {
                    foundCardPref = true;
                    //swap card to index 0 in deck, then instantiate and break out of loop
                    if(string.Equals(temp.GetComponent<ThisCardEnemy>().thisId, Deck.staticEnemyDeck[0].id))
                    {
                        Instantiate(CardToPlay, transform.position, transform.rotation);
                    }
                    else
                    {
                        Card swap = Deck.staticEnemyDeck[0];
                        Deck.staticEnemyDeck[0] = Deck.staticEnemyDeck[cardCount];
                        Deck.staticEnemyDeck[cardCount] = swap;
                        Instantiate(CardToPlay, transform.position, transform.rotation);
                    }
                }
            }

            cardCount++;
            Destroy(temp);
        }

        cardCount = 0;

        //if no card with pref is found, play first valid card
        if (foundCardPref == false)
        {
            validCard = false;

            while (cardCount < 5 && validCard == false)
            {
                //grab first card from deck, pass it into checkDefense

                GameObject temp = new GameObject();
                temp.AddComponent<ThisCardEnemy>();
                temp.GetComponent<ThisCardEnemy>().SetIDAndType(Deck.staticEnemyDeck[cardCount].id, Deck.staticEnemyDeck[cardCount].cardType);
                //check if card we are checking is attack, defense or asset

                //defense
                if (temp.GetComponent<ThisCardEnemy>().thisId >= 0 && temp.GetComponent<ThisCardEnemy>().thisId <= 3)
                {
                    validCard = enemyDefenseArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
                }
                //attack
                else if (temp.GetComponent<ThisCardEnemy>().thisId >= 4 && temp.GetComponent<ThisCardEnemy>().thisId <= 13)
                {
                    validCard = enemyAttackArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
                }
                //asset
                else if (temp.GetComponent<ThisCardEnemy>().thisId >= 14 && temp.GetComponent<ThisCardEnemy>().thisId <= 18)
                {
                    validCard = enemyAssetArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
                }
                //special
                else
                {
                    validCard = enemyAttackArea.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);
                }
                //validCard = playAreaEnemy.GetComponent<EnemyPlayArea>().checkDefenseEnemy(temp);

                //if card is valid, check preference - else, continue
                if (validCard)
                {

                    //swap card to index 0 in deck, then instantiate and break out of loop
                    if (string.Equals(temp.GetComponent<ThisCardEnemy>().thisId, Deck.staticEnemyDeck[0].id))
                    {
                        Instantiate(CardToPlay, transform.position, transform.rotation);
                    }
                    else
                    {
                        Card swap = Deck.staticEnemyDeck[0];
                        Deck.staticEnemyDeck[0] = Deck.staticEnemyDeck[cardCount];
                        Deck.staticEnemyDeck[cardCount] = swap;
                        Instantiate(CardToPlay, transform.position, transform.rotation);
                    }

                }

                cardCount++;
                Destroy(temp);
            }
        }

        if(validCard == false)
        {
            Debug.Log("No valid card found to play");
        }

        StartCoroutine(EnemyEndTurn());
    }


    /*IEnumerator waitCoroutine()
    {
        //Debug.Log("Started enemy turn at timestamp: " + Time.time);
        yield return new WaitForSeconds(1);

        //instantiate card from enemy deck to play
        bool foundCardPref;
        int cardCount;

        foundCardPref = false;
        cardCount = 0;

        //check for preference - goes through card in hand, if card matches pref play it, else cycle until end
        while (cardCount < 5 && foundCardPref == false){

            Instantiate(CardToPlay, transform.position, transform.rotation);
            yield return new WaitForSeconds(2);
            if (playAreaEnemy.transform.childCount > 0)
            {

                int lastChildIndex = playAreaEnemy.transform.childCount - 1;

                ThisCardEnemy recentCardPlayed = playAreaEnemy.transform.GetChild(lastChildIndex).GetComponent<ThisCardEnemy>();
                recentCardPlayed.gameObject.SetActive(false);
                if (string.Equals(recentCardPlayed.cardTypeID, cardPref))
                {
                    foundCardPref = true;
                    Debug.Log("Card matches card pref: " + recentCardPlayed.cardTypeID);
                    recentCardPlayed.gameObject.SetActive(true);
                }
                else
                {
                    cardCount++;
                    //Deck.staticEnemyDeck.Add(new Card(recentCardPlayed.thisId, recentCardPlayed.cardTypeID, recentCardPlayed.cardName, recentCardPlayed.cardDamage,
                    //recentCardPlayed.cardPoints, recentCardPlayed.cardDefense, recentCardPlayed.cardDesc, recentCardPlayed.numberOfCardsInDeck));
                    Deck.staticEnemyDeck.Insert(4, new Card(recentCardPlayed.thisId, recentCardPlayed.cardTypeID, recentCardPlayed.cardName, recentCardPlayed.cardDamage,
                 recentCardPlayed.cardPoints, recentCardPlayed.cardDefense, recentCardPlayed.cardDesc, recentCardPlayed.numberOfCardsInDeck));
                    Destroy(recentCardPlayed.gameObject);
                }
            }
            
        }

        Debug.Log(playAreaEnemy.transform.childCount);

        if(foundCardPref == false){
            Debug.Log("couldn't find card pref, playing next available card");
            Instantiate(CardToPlay, transform.position, transform.rotation);
        }


       

        yield return new WaitForSeconds(1);

        //Debug.Log("Ended enemy turn at timestamp : " + Time.time);
        
        EnemyEndTurn();
    }*/

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

    IEnumerator waitAMin()
    {
        yield return new WaitForSeconds(5);
    }

    // IEnumerator drawCardEnemy(){
    //     yield return new WaitForSeconds(1);
    //     Instantiate(CardToHandEnemy, transform.position, transform.rotation);
    // }

}