using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandDrop : MonoBehaviour
{
    public GameObject cardArea;
	
    public void OnDrop(PointerEventData eventData)
	{
		if(eventData.pointerDrag != null)
		{
			eventData.pointerDrag.GetComponent<ThisCard>().lastParent = cardArea.transform.name;
			eventData.pointerDrag.transform.SetParent(cardArea.transform);
			eventData.pointerDrag.transform.localScale = new Vector3(3, 3, 3);
			eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
			eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
			//calls card effect
			eventData.pointerDrag.transform.GetComponent<Card>().cardActive = true;
			eventData.pointerDrag.transform.GetComponent<Drag>().parentToReturnTo = this.transform;

			//figured out how to access card and discard it!!!!
			//eventData.pointerDrag.transform.GetComponent<Card>().MoveToDiscardPile();
			//Debug.Log ("Card discarded");
		}
	}
}
