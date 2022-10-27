using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*Script that allows a card to be dropped down*/
public class PlayDrop : MonoBehaviour, IDropHandler
{
	public GameObject playArea;
	public GameObject cardArea;

	public GameObject hardwareScreen;

    public void OnDrop(PointerEventData eventData)
	{
		if(eventData.pointerDrag != null)
		{

			//if called card is unplayable at the moment
			if(eventData.pointerDrag.gameObject.GetComponent<ThisCard>().isBlocked == true)
            {
				eventData.pointerDrag.transform.SetParent(cardArea.transform);
				eventData.pointerDrag.transform.localScale = Vector3.one;
				eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
				eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
				//calls card effect
				//eventData.pointerDrag.transform.GetComponent<Card>().cardActive = true;
				eventData.pointerDrag.transform.GetComponent<Drag>().parentToReturnTo = this.transform;
			}
			//else if card played is hardware failure
			else if(eventData.pointerDrag.gameObject.GetComponent<ThisCard>().thisId == 19)
            {
				//call hardware failure script
				hardwareScreen.GetComponent<HardwareFailure>().StartUI();
				Destroy(eventData.pointerDrag.gameObject);
            }
			else
            {
				eventData.pointerDrag.transform.SetParent(playArea.transform);
				eventData.pointerDrag.transform.localScale = Vector3.one;
				eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
				eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
				//calls card effect
				//eventData.pointerDrag.transform.GetComponent<Card>().cardActive = true;
				eventData.pointerDrag.transform.GetComponent<Drag>().parentToReturnTo = this.transform;
			}
			

			//figured out how to access card and discard it!!!!
			//eventData.pointerDrag.transform.GetComponent<Card>().MoveToDiscardPile();
			//Debug.Log ("Card discarded");
		}
		cardArea.transform.GetComponent<PlayerCardArea>().checkForDefense();

	}

	void Update(){
		
	}
}
