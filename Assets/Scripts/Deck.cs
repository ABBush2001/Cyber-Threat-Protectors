using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	public List<Card> deck = new List<Card>();
	public static List<Card> staticDeck = new List<Card>();
	public List<Card> cardValues = new List<Card>();
	
	public int x;
	public static int deckSize;
	
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
		deckSize = 54;
		CardDatabase.FillList(cardValues);
		
		for(int i = 0; i < deckSize; i++)
		{
			x = Random.Range(0, 3);
			deck.Add(cardValues[x]);
		}
		
		staticDeck = deck;
		
    }

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;
    }
}
