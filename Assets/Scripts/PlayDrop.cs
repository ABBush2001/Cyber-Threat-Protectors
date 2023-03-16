using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

/*Script that allows a card to be dropped down*/
public class PlayDrop : MonoBehaviour, IDropHandler
{
	public GameObject playerAttackArea;
    public GameObject playerDefenseArea;
    public GameObject playerAssetArea;
	public GameObject playercardArea;

    public GameObject enemyAttackArea;
    public GameObject enemyDefenseArea;
    public GameObject enemyAssetArea;

    public GameObject hardwareScreen;
	public GameObject forgotToPatchScreen;

    public void OnDrop(PointerEventData eventData)
	{
		if(eventData.pointerDrag != null)
		{

			//if called card is unplayable at the moment
			if(eventData.pointerDrag.gameObject.GetComponent<ThisCard>().isBlocked == true)
            {
                eventData.pointerDrag.GetComponent<ThisCard>().lastParent = playercardArea.transform.name;
                eventData.pointerDrag.transform.SetParent(playercardArea.transform);
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

				for(j = 0;  j < enemyAssetArea.transform.childCount; j++)
				{
					if(enemyAssetArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId >= 14 && enemyAssetArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId <= 18)
					{
                        //call hardware failure script
                        hardwareScreen.GetComponent<HardwareFailure>().StartUI();
                        Destroy(eventData.pointerDrag.gameObject);
						return;
                    }
				}

                //else
                eventData.pointerDrag.GetComponent<ThisCard>().lastParent = playercardArea.transform.name;
                eventData.pointerDrag.transform.SetParent(playercardArea.transform);
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

                for (j = 0; j < enemyDefenseArea.transform.childCount; j++)
                {
                    if (enemyDefenseArea.transform.GetChild(j).GetComponent<ThisCardEnemy>().thisId == 3 || enemyAttackArea.transform.childCount + enemyAssetArea.transform.childCount + enemyDefenseArea.transform.childCount >= 2)
                    {
                        //check if security training in play
                        int i;

                        for (i = 0; i < enemyDefenseArea.transform.childCount; i++)
                        {
                            if (enemyDefenseArea.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 3)
                            {
                                enemyDefenseArea.transform.GetChild(i).GetComponent<ForgotToPatchDestroy>().secTrain = true;
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
                eventData.pointerDrag.GetComponent<ThisCard>().lastParent = playercardArea.transform.name;
                eventData.pointerDrag.transform.SetParent(playercardArea.transform);
                eventData.pointerDrag.transform.localScale = Vector3.one;
                eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
                //calls card effect
                //eventData.pointerDrag.transform.GetComponent<Card>().cardActive = true;
                eventData.pointerDrag.transform.GetComponent<Drag>().parentToReturnTo = this.transform;
            }
			else
            {
                //defense card
                if(eventData.pointerDrag.GetComponent<ThisCard>().thisId >= 0 && eventData.pointerDrag.GetComponent<ThisCard>().thisId <= 3)
                {
                    //check to see if this defense card is already in play
                    for(int i = 0; i < playerDefenseArea.transform.childCount; i++)
                    {
                        if(playerDefenseArea.transform.GetChild(i).GetComponent<ThisCard>().thisId == eventData.pointerDrag.GetComponent<ThisCard>().thisId)
                        {
                            eventData.pointerDrag.GetComponent<ThisCard>().lastParent = playercardArea.transform.name;
                            eventData.pointerDrag.transform.SetParent(playercardArea.transform);
                            eventData.pointerDrag.transform.localScale = Vector3.one;
                            eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                            eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
                            return;
                        }
                    }

                    eventData.pointerDrag.GetComponent<ThisCard>().lastParent = GameObject.Find("Player Defense Area").transform.name;
                    eventData.pointerDrag.transform.SetParent(GameObject.Find("Player Defense Area").transform);
                    eventData.pointerDrag.transform.localScale = Vector3.one;
                    eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                    eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
                }
                //attack card
                else if (eventData.pointerDrag.GetComponent<ThisCard>().thisId >= 4 && eventData.pointerDrag.GetComponent<ThisCard>().thisId <= 13)
                {
                    eventData.pointerDrag.GetComponent<ThisCard>().lastParent = GameObject.Find("Player Attack Area").transform.name;
                    eventData.pointerDrag.transform.SetParent(GameObject.Find("Player Attack Area").transform);
                    eventData.pointerDrag.transform.localScale = Vector3.one;
                    eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                    eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
                }
                //asset card
                else
                {
                    eventData.pointerDrag.GetComponent<ThisCard>().lastParent = GameObject.Find("Player Asset Area").transform.name;
                    eventData.pointerDrag.transform.SetParent(GameObject.Find("Player Asset Area").transform);
                    eventData.pointerDrag.transform.localScale = Vector3.one;
                    eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                    eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
                }

                /*eventData.pointerDrag.GetComponent<ThisCard>().lastParent = playArea.transform.name;
                eventData.pointerDrag.transform.SetParent(playArea.transform);
				eventData.pointerDrag.transform.localScale = Vector3.one;
				eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
				eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);*/
                //calls card effect
                //eventData.pointerDrag.transform.GetComponent<Card>().cardActive = true;
                //eventData.pointerDrag.transform.GetComponent<Drag>().parentToReturnTo = this.transform;

                //destroy card's drag component
                Destroy(eventData.pointerDrag.gameObject.GetComponent<Drag>());
			}
			

			//figured out how to access card and discard it!!!!
			//eventData.pointerDrag.transform.GetComponent<Card>().MoveToDiscardPile();
			//Debug.Log ("Card discarded");
		}
		playercardArea.transform.GetComponent<PlayerCardArea>().checkForDefense();
		

	}

	void Update(){
		
	}
}
