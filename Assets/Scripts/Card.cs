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
	public string cardDesc;
	
	public Card()
	{
		
	}
	
	public Card(int Id, string CardType, string CardName, int Damage, int Points, string CardDesc)
	{
		id = Id;
		cardType = CardType;
		cardName = CardName;
		damage = Damage;
		points = Points;
		cardDesc = CardDesc;
	}
	
}
