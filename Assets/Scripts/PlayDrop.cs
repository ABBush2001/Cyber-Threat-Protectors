using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*Script that allows a card to be dropped down*/
public class PlayDrop : MonoBehaviour, IDropHandler
{
	public GameObject Hand;
	
    public void OnDrop(PointerEventData eventData)
	{
		if(eventData.pointerDrag != null)
		{
			eventData.pointerDrag.transform.SetParent(Hand.transform);
			eventData.pointerDrag.transform.localScale = Vector3.one;
			eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
			eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
			//figured out how to access card and discard it!!!!
			//eventData.pointerDrag.transform.GetComponent<Card>().MoveToDiscardPile();
			//Debug.Log ("Card discarded");
		}
	}
}
