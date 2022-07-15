using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

/*Script representing a specific instance of the card object*/
public class ThisCardEnemy : MonoBehaviour
{
	public List<Card> cList = new List<Card>();
    public int thisId;

    public string cardName;
    public string cardDesc;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = UnityEngine.Random.Range(0, 3);
        thisId = randomNumber;
        CardDatabase.FillList(cList);

        numberOfCardsInDeck = Deck.deckSize;

        cardDesc = Deck.staticEnemyDeck[0].cardDesc;
        cardName = Deck.staticEnemyDeck[0].cardName;

        Deck.staticEnemyDeck.RemoveAt(0);

    }

    // Update is called once per frame
    void Update()
    {

        Hand = GameObject.Find("Enemy Card Area");
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = true;
        }

        try
        {
            staticCardBack = cardBack;
        }
        catch(NullReferenceException e)
        {

        }
        

        nameText.text = "" + cardName;
        descriptionText.text = "" + cardDesc;

        if(this.tag == "Clone")
        {
            

            thisId = Deck.staticPlayerDeck[numberOfCardsInDeck - 1].id;
            numberOfCardsInDeck -= 1;
            Deck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";

            Debug.Log("Num of Cards: " + numberOfCardsInDeck + ", " + Deck.deckSize);
        }
    }
}
