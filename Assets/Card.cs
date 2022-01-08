using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

//class representing a card object
public class Card : MonoBehaviour
{

    public int id; //each card has a unique id
    public string cardName; //the name of the card
    public string cardType; //whether the card is attack, defense or asset
    public int cost; //how many points this card takes away from an enemy, if any
    public string cardDesc; //description of the card and its effects

    public Card()
    {

    }

    //constructor for card
    public Card(int Id, string CardType, string CardName, int Cost, string CardDesc)
    {
        id = Id;
        cardType = CardType;
        cardName = CardName;
        cost = Cost;
        cardDesc = CardDesc;
    }
}
