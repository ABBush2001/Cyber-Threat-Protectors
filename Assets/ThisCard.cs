using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{

    public List<Card> cList = new List<Card>();
    public int thisId;

    public string cardName;
    public string cardDesc;

    public Text nameText;
    public Text descriptionText;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = UnityEngine.Random.Range(0, 3);
        thisId = randomNumber;
        CardDatabase.fillList(cList);

        
        numberOfCardsInDeck = PlayerDeck.deckSize;
    }

    // Update is called once per frame
    void Update()
    {

        Hand = GameObject.Find("Hand");
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
        

        cardDesc = cList[thisId].cardDesc;
        cardName = cList[thisId].cardName;


        nameText.text = "" + cardName;
        descriptionText.text = "" + cardDesc;

        if(this.tag == "Clone")
        {
            

            thisId = PlayerDeck.staticDeck[numberOfCardsInDeck - 1].id;
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";

            Debug.Log("Num of Cards: " + numberOfCardsInDeck + ", " + PlayerDeck.deckSize);
        }
    }
}
