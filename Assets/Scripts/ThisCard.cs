using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

/*Script representing a specific instance of the card object*/
public class ThisCard : MonoBehaviour
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

    public string cardTypeID;
    public int cardPoints;
    public int cardDamage;
    public int cardDefense;

    public bool isBlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCardsInDeck = Deck.deckSize;

        thisId = Deck.staticPlayerDeck[0].id;
        cardDesc = Deck.staticPlayerDeck[0].cardDesc;
        cardName = Deck.staticPlayerDeck[0].cardName;

        cardTypeID = Deck.staticPlayerDeck[0].cardType;
        cardPoints = Deck.staticPlayerDeck[0].points;
        cardDamage = Deck.staticPlayerDeck[0].damage;
        cardDefense = Deck.staticPlayerDeck[0].defense;

        Deck.staticPlayerDeck.RemoveAt(0);

    }

    // Update is called once per frame
    void Update()
    {

        Hand = GameObject.Find("Player Card Area");
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
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
