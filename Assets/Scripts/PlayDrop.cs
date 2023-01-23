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
	public GameObject forgotToPatchScreen;

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
			//else if card played is hardware failure AND enemy has an asset card in play
			else if(eventData.pointerDrag.gameObject.GetComponent<ThisCard>().thisId == 19)
            {
				int j;

				for(j = 0;  j < GameObject.Find("Enemy Play Area").transform.childCount; j++)
				{
					if(GameObject.Find("Enemy Play Area").transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId >= 14 && GameObject.Find("Enemy Play Area").transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId <= 18)
					{
                        //call hardware failure script
                        hardwareScreen.GetComponent<HardwareFailure>().StartUI();
                        Destroy(eventData.pointerDrag.gameObject);
						return;
                    }
				}

                //else
                eventData.pointerDrag.transform.SetParent(cardArea.transform);
                eventData.pointerDrag.transform.localScale = Vector3.one;
                eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
                //calls card effect
                //eventData.pointerDrag.transform.GetComponent<Card>().cardActive = true;
                eventData.pointerDrag.transform.GetComponent<Drag>().parentToReturnTo = this.transform;

            }
			//else if card played is forgot to patch AND there are at least two cards in play OR Security Training in play
			else if(eventData.pointerDrag.gameObject.GetComponent<ThisCard>().thisId == 20)
			{
				int j;

                for (j = 0; j < GameObject.Find("Enemy Play Area").transform.childCount; j++)
                {
                    if (GameObject.Find("Enemy Play Area").transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 3 || GameObject.Find("Enemy Play Area").transform.childCount >= 2)
                    {
                        //check if security training in play
                        int i;

                        for (i = 0; i < GameObject.Find("Enemy Play Area").transform.childCount; i++)
                        {
                            if (GameObject.Find("Enemy Play Area").transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 3)
                            {
                                GameObject.Find("Enemy Play Area").transform.GetChild(i).GetComponent<ForgotToPatchDestroy>().secTrain = true;
                                break;
                            }
                        }

                        //call forgot to patch script
                        forgotToPatchScreen.GetComponent<ForgotToPatch>().StartUI();
                        Destroy(eventData.pointerDrag.gameObject);
                        return;
                    }
                }

                //else
                eventData.pointerDrag.transform.SetParent(cardArea.transform);
                eventData.pointerDrag.transform.localScale = Vector3.one;
                eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
                //calls card effect
                //eventData.pointerDrag.transform.GetComponent<Card>().cardActive = true;
                eventData.pointerDrag.transform.GetComponent<Drag>().parentToReturnTo = this.transform;
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
