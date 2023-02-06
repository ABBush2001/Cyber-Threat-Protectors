using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
	public List<Card> playerDeck = new List<Card>();
	public static List<Card> staticPlayerDeck = new List<Card>();
	public List<Card> enemyDeck = new List<Card>();
	public static List<Card> staticEnemyDeck = new List<Card>();
	public List<Card> cardValues = new List<Card>();
	
	public static int deckSize;

	private static System.Random rng = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
		deckSize = 54;
		CardDatabase.FillList(cardValues);
		
		//for each card type, iterate through its numInDeck and generate that many cards
		//21
		for(int i = 0; i < 21; i++)
		{
			for(int j = 0; j < cardValues[i].numInDeck; j++)
			{
				playerDeck.Add(cardValues[i]);
				//Debug.Log(cardValues[i].getName());
				enemyDeck.Add(cardValues[i]);
			}
		}
		
		//shuffle the decks
		Shuffle(playerDeck);
		Shuffle(enemyDeck);

		staticPlayerDeck = playerDeck;
		staticEnemyDeck = enemyDeck;
		
    }

	//shuffled with the fisher-yates algorithm
	public static void Shuffle(List<Card> list)
	{
		int n = list.Count;
		while(n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			Card value = list[k];
			list[k] = list[n];
			list[n] = value;
		}

	}

}
