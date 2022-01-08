using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    //create a list to hold all the cards in our deck
    public static List<Card> cardList = new List<Card> ();

    //function to create all the different cards in our deck
    public static void fillList (List<Card> cList)
    {
        cList.Add(new Card(0, "Defense", "Test Defense", 0, "Block 1 Damage"));
        cList.Add(new Card(1, "Attack", "Test Attack", 1, "Deal 1 Damage"));
        cList.Add(new Card(2, "Asset", "Test Asset", 0, "Generate 1 point per round"));


    }
}
