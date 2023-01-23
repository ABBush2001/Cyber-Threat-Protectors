using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

/*class representing a card object*/
public class Card : MonoBehaviour
{
    public int id;
	public string cardName;
	public string cardType;
	public int damage;
	public int points;
	public int defense;
	public string cardDesc;
	public bool cardActive;
	public int numInDeck; 

	private EventManager em;


	public Collider2D myTarget { get; set;}

	

	private void Start(){
		em = FindObjectOfType<EventManager>();
	}

	void Update()
	{	
		if(cardActive){
			em.card = this;
			em.targetOn = true;
			if(em.playAreaEnemy.transform.childCount >= 1 ){
				cardEffect();
			}
			else{
				cardActive = false;
				em.targetOn = false;
			}
			
		}
	}
	
	public Card()
	{
		
	}
	
	public Card(int Id, string CardType, string CardName, int Damage, int Points, int Defense, string CardDesc, int NumInDeck)
	{
		id = Id;
		cardType = CardType;
		cardName = CardName;
		damage = Damage;
		points = Points;
		defense = Defense;
		cardDesc = CardDesc;
		cardActive = false;
		numInDeck = NumInDeck;
	}

	public void MoveToDiscardPile(){
		em.discardPile.Add(this);
		Destroy(gameObject);
	}

	public void addToDeck(bool playerCard){
		if(playerCard){
			//em.staticPlayerDeck.Add(this);
		}
		else
			//em.staticEnemyDeck.Add(this);
		Destroy(gameObject);
	}

	public void cardEffect(){
		//select enemy card
		if(myTarget != null){
			//call its discard method
			myTarget.gameObject.GetComponent<Card>().MoveToDiscardPile();
			cardActive = false;
			myTarget = null;
		}
		
	}

	public string getName()
	{
		return cardName;
	}

}
