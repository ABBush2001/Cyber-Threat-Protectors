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

	public Transform myTarget { get; set;}

	

	private void Start(){
		em = FindObjectOfType<EventManager>();
	}

	void Update()
	{	
		
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

	public void cardEffect(){
		//select enemy card
		cardActive = true;
		//call its discard method
	}

	public void ClickTarget(){
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity,256);

            if(hit.collider != null)
            {
                myTarget = hit.transform;
				hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				//myTarget.GetComponent<Card>().MoveToDiscardPile();

            }
            else
            {
                myTarget = null;
            }
        }
    }
	
}
