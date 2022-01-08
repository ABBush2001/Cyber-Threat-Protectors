using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> cardValues = new List<Card>();

    public int x;
    public int deckSize;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        deckSize = 54;
        CardDatabase.fillList(cardValues);

        for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(0, 3);
            deck[i] = cardValues[x];
            Debug.Log("(" + i + ") " + deck[i].cardName + ": " + deck[i].cardDesc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
