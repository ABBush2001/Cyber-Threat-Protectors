using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayArea : MonoBehaviour
{
    public GameObject CardToPlay;

    public GameObject playArea;
    public GameObject enemyPlayArea;
	private int playerChildID;
    private int cardID;
    private bool validCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public bool checkDefenseEnemy(GameObject It){
        cardID = It.GetComponent<ThisCardEnemy>().thisId;
        if (cardID == 11 || cardID == 5 || cardID == 19)
        {
            validCard = false;
        }
        else
        {
            validCard = true;
        }
        //check if player played a defense card that blocks this card being played
        foreach(Transform playAreaChild in playArea.transform){
            playerChildID = playAreaChild.GetComponent<ThisCard>().thisId;
            //0 blocks 6 and 10
            if(playerChildID == 0 && (cardID == 6 || cardID == 10)){
                validCard = false;
                //Instantiate(CardToPlay, transform.position, transform.rotation);
            }
            //1 blocks 4
            else if(playerChildID == 1 && (cardID == 4)){
                validCard = false;
                //Instantiate(CardToPlay, transform.position, transform.rotation);
            }
            //2 blocks 9 and 12
            else if(playerChildID == 2 && (cardID == 9 || cardID == 12)){
                validCard = false;
                //Instantiate(CardToPlay, transform.position, transform.rotation);
            }
            //3 blocks 7 and 8
            else if(playerChildID == 3 && (cardID == 7 || cardID == 8)){
                validCard = false;
                //Instantiate(CardToPlay, transform.position, transform.rotation);
            }
            //if it does, dont play it down and try instantiating another card
            //remember to add it back to the enemy deck

            //also check if enemy has played firewall or encryption, allowing firewall
            //not updated and weak encryption key to be played, respectively
            else if(playerChildID == 2 && cardID == 11)
            {
                validCard = true;
            }
            else if(playerChildID == 1 && cardID == 5)
            {
                validCard = true;
            }

            //check for hardware failure - can only be played when enemy has asset card in play
            else if(cardID == 19 && (playerChildID >= 14 && playerChildID <= 18))
            {
                validCard = true;
            }
        }
        //check if the same card is on the field aswell 
        if(cardID <= 3){
            foreach(Transform enemyCard in enemyPlayArea.transform){
            if(enemyCard.GetComponent<ThisCardEnemy>().thisId == cardID){
                Debug.Log("Same card already in play");
                validCard = false;
                //Instantiate(CardToPlay, transform.position, transform.rotation);
            }
        }
        }
        
        return validCard;
    }
}
