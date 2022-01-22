using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script representing the database of cards*/
public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card> ();
	
	public static void FillList(List<Card> cList)
	{
		cList.Add(new Card(0, "Defense", "Test Defense", 0, 0, "Block 1 Damage"));
		cList.Add(new Card(1, "Attack", "Test Attack", 1, 0, "Deal 1 Damage"));
		cList.Add(new Card(2, "Asset", "Test Asset", 0, 1, "Generate 1 Point Per Round"));
	}
}
