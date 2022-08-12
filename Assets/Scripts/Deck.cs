using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	public List<Card> playerDeck = new List<Card>();
	public static List<Card> staticPlayerDeck = new List<Card>();
	public List<Card> enemyDeck = new List<Card>();
	public static List<Card> staticEnemyDeck = new List<Card>();
	public List<Card> cardValues = new List<Card>();
	
	public int x;
	public int y;
	public static int deckSize;
	
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
		y = 0;
		deckSize = 54;
		CardDatabase.FillList(cardValues);
		
		for(int i = 0; i < deckSize; i++)
		{
			x = Random.Range(0, 20);
			y = Random.Range(0, 20);
			playerDeck.Add(cardValues[x]);
			enemyDeck.Add(cardValues[y]);
		}
		
		staticPlayerDeck = playerDeck;
		staticEnemyDeck = enemyDeck;
		
    }

    // Update is called once per frame
    void Update()
    {
        //staticPlayerDeck = playerDeck;
		//staticEnemyDeck = enemyDeck;
		
    }
}
