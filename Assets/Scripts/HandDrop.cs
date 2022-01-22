using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandDrop : MonoBehaviour, IDropHandler
{
    public GameObject Hand;
	
    public void OnDrop(PointerEventData eventData)
	{
		if(eventData.pointerDrag != null)
		{
			Hand = GameObject.Find("Player Card Area");
			eventData.pointerDrag.transform.SetParent(Hand.transform);
			eventData.pointerDrag.transform.localScale = Vector3.one;
			eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
			eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
		}
	}
}
