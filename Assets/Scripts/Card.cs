using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

/*class representing a card object*/
public class Card : MonoBehaviour
{
    public int id;
	public string cardName;
	public int cardType;
	public int damage;
	public int points;
	public int defense;
	public string cardDesc;
	public bool cardActive;

	private EventManager em;

	private void Start(){
		em = FindObjectOfType<EventManager>();
	}
	
	public Card()
	{
		
	}
	
	public Card(int Id, int CardType, string CardName, int Damage, int Points, int Defense, string CardDesc)
	{
		id = Id;
		cardType = CardType;
		cardName = CardName;
		damage = Damage;
		points = Points;
		defense = Defense;
		cardDesc = CardDesc;
		cardActive = false;
	}

	public void MoveToDiscardPile(){
		em.discardPile.Add(this);
		gameObject.SetActive(false);
	}
	
}
