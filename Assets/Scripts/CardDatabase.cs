using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script representing the database of cards*/
public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card> ();
	
	public static void FillList(List<Card> cList)
	{
		cList.Add(new Card(0, 0, "Test Defense", 0, 0, 1, "Block 1 Damage"));
		cList.Add(new Card(1, 1, "Test Attack", 1, 0, 0, "Deal 1 Damage"));
		cList.Add(new Card(2, 2, "Test Asset", 0, 1, 0, "Generate 1 Point Per Round"));
	}
}
