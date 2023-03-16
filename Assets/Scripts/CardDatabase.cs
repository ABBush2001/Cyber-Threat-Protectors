using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script representing the database of cards*/
public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card> ();
	

	public static void FillList(List<Card> cList)
	{
		//defense
		cList.Add(new Card(0, "Defense", "Anti-Malware", 0, 0, 1, "Blocks:\n I Love You Virus \n Trojan Horse \n\nRemoves \n I Love You Virus \n Trojan Horse \n Anti-Malware Not Updated \n\n You may only have 1 of this card in play at any time", 3));
		cList.Add(new Card(1, "Defense", "Encryption", 0, 0, 1, "Blocks:\n Wireless Sniffing \n Weak Encryption Key \n\nRemoves \n Wireless Sniffing \n Weak Encryption Key \n\n You may only have 1 of this card in play at any time", 3));
		cList.Add(new Card(2, "Defense", "Firewall", 0, 0, 1, "Blocks:\n Denial of Service \n IP Spoofing \n\nRemoves \n Denial of Service \n Firewall Rules Not Updated \n IP Spoofing \n\n You may only have 1 of this card in play at any time", 3));
		cList.Add(new Card(3, "Defense", "Security Training", 0, 0, 1, "Blocks:\n Password Cracked \n Phishing \n\nRemoves \n Password Cracked \n Phishing \n\n You may only have 1 of this card in play at any time", 3));
		//attack
		cList.Add(new Card(4, "Attack", "Wireless Sniffing", 1, 0, 0, "Subtract:\n -1\n\n Can only be played if your opponent does not have an 'Encryption' card in play", 3));
		cList.Add(new Card(5, "Attack", "Weak Encryption Key", 1, 0, 0, "Subtract:\n -1\n\n Can only be played if your opponent has an 'Encryption' card in play. Remove your opponent's 'Encryption' card. You may only have 1 of this card in play at any time.", 2));
		cList.Add(new Card(6, "Attack", "Trojan Horse", 1, 0, 0, "Subtract:\n -1\n\n Can only be played if your opponent does not have an 'Anti-Malware' card in play", 2));
		cList.Add(new Card(7, "Attack", "Phishing", 1, 0, 0, "Subtract:\n -1\n\n Can only be played if your opponent does not have a 'Security Training' card in play", 3));
		cList.Add(new Card(8, "Attack", "Password Cracked", 1, 0, 0, "Subtract:\n -1\n\n Can only be played if your opponent does not have a 'Security Training' card in play", 3));
		cList.Add(new Card(9, "Attack", "IP Spoofing", 1, 0, 0, "Subtract:\n -1\n\n Can only be played if your opponent does not have a 'Firewall' card in play", 2));
		cList.Add(new Card(10, "Attack", "I Love You Virus", 1, 0, 0, "Subtract:\n -1\n\n Can only be played if your opponent does not have an 'Anti-Malware' card in play", 2));
		cList.Add(new Card(11, "Attack", "Firewall Rules Not Updated", 1, 0, 0, "Subtract:\n -1\n\n Can only play if your opponent has a 'Firewall' card. Remove your opponents 'Firewall' card. You may only have 1 of this card in play at any time.", 2));
		cList.Add(new Card(12, "Attack", "Denial of Service", 1, 0, 0, "Subtract:\n -1\n\n Can only be played if your opponent does not have a 'Firewall' card in play", 2));
		cList.Add(new Card(13, "Attack", "Anti-Malware Not Updated", 1, 0, 0, "Subtract:\n -1\n\n Can only be played if your opponent has an 'Anti-Malware' card in play. Remove your opponent's 'Anti-Malware' card. You may only have 1 'Anti-Malware Not Updated' card in play at a time", 2));
		//asset
		cList.Add(new Card(14, "Asset", "Wireless Router", 0, 1, 0, "Generate 1 Point Per Round", 2));
		cList.Add(new Card(15, "Asset", "Server", 0, 1, 0, "Generate 1 Point Per Round", 2));
		cList.Add(new Card(16, "Asset", "Laptop", 0, 1, 0, "Generate 1 Point Per Round", 3));
		cList.Add(new Card(17, "Asset", "ISP Connection", 0, 1, 0, "Generate 1 Point Per Round", 4));
		cList.Add(new Card(18, "Asset", "Desktop Computer", 0, 1, 0, "Generate 1 Point Per Round", 3));

		//special
		cList.Add(new Card(19, "Special", "Hardware Failure", 0, 0, 0, "Select one Asset from your opponents field. Remove both the selected card and this card", 3));
		cList.Add(new Card(20, "Special", "Forgot To Patch", 0, 0, 0, "If 'Security Training' is in play, send this card and the 'Security Training' card to the discard pile. \n\nElse, choose 2 cards frm your opponent's hand and remove both those cards and this card.", 2));
	
	
	}
}
