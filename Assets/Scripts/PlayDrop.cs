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

    public GameObject eventSystem;

    private CanvasGroup canvasGroup;

    public void OnDrop(PointerEventData eventData)
	{
        canvasGroup = eventData.pointerDrag.gameObject.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = true;
		if(eventData.pointerDrag != null && eventData.pointerDrag.gameObject.GetComponent<Drag>())
		{
            //StartCoroutine(animWaitForHover(eventData.pointerDrag.gameObject, new Vector3(1, 1, 1)));


            //if called card is unplayable at the moment
            if (eventData.pointerDrag.gameObject.GetComponent<ThisCard>().isBlocked == true)
            {
                StartCoroutine(animWaitForHover(eventData.pointerDrag.gameObject, new Vector3(1, 1, 1)));

                eventData.pointerDrag.GetComponent<ThisCard>().lastParent = playercardArea.transform.name;
                eventData.pointerDrag.transform.SetParent(playercardArea.transform);
				//eventData.pointerDrag.transform.localScale = Vector3.one;
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
                //StartCoroutine(animWaitForHover(eventData.pointerDrag.gameObject, new Vector3(1, 1, 1)));

                eventData.pointerDrag.GetComponent<ThisCard>().lastParent = playercardArea.transform.name;
                eventData.pointerDrag.transform.SetParent(playercardArea.transform);
                //eventData.pointerDrag.transform.localScale = Vector3.one;
                eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);
                //calls card effect
                //eventData.pointerDrag.transform.GetComponent<Card>().cardActive = true;
                eventData.pointerDrag.transform.GetComponent<Drag>().parentToReturnTo = this.transform;

                

            }
			//else if card played is forgot to patch AND there are at least two cards in play OR Security Training in play
			else if(eventData.pointerDrag.gameObject.GetComponent<ThisCard>().thisId == 20)
			{
                eventSystem.GetComponent<ForgotToPatch>().StartUI();
                Destroy(eventData.pointerDrag.gameObject);
                
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
                            StartCoroutine(animWaitForHover(eventData.pointerDrag.gameObject, new Vector3(1, 1, 1)));

                            eventData.pointerDrag.GetComponent<ThisCard>().lastParent = playercardArea.transform.name;
                            eventData.pointerDrag.transform.SetParent(playercardArea.transform);
                            //eventData.pointerDrag.transform.localScale = Vector3.one;
                            eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                            eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);

                            
                            return;
                        }
                    }

                    Destroy(eventData.pointerDrag.gameObject.GetComponent<Drag>());
                    StartCoroutine(animWaitForHover(eventData.pointerDrag.gameObject, new Vector3(1.5f, 1, 1)));

                    eventData.pointerDrag.GetComponent<ThisCard>().lastParent = GameObject.Find("Player Defense Area").transform.name;
                    eventData.pointerDrag.transform.SetParent(GameObject.Find("Player Defense Area").transform);
                    //eventData.pointerDrag.transform.localScale = Vector3.one;
                    eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                    eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);

                    
                }
                //attack card
                else if (eventData.pointerDrag.GetComponent<ThisCard>().thisId >= 4 && eventData.pointerDrag.GetComponent<ThisCard>().thisId <= 13)
                {
                    Destroy(eventData.pointerDrag.gameObject.GetComponent<Drag>());
                    StartCoroutine(animWaitForHover(eventData.pointerDrag.gameObject, new Vector3(1.5f, 1, 1)));

                    eventData.pointerDrag.GetComponent<ThisCard>().lastParent = GameObject.Find("Player Attack Area").transform.name;
                    eventData.pointerDrag.transform.SetParent(GameObject.Find("Player Attack Area").transform);
                    //eventData.pointerDrag.transform.localScale = Vector3.one;
                    eventData.pointerDrag.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
                    eventData.pointerDrag.transform.eulerAngles = new Vector3(25, 0, 0);

                    
                }
                //asset card
                else
                {
                    Destroy(eventData.pointerDrag.gameObject.GetComponent<Drag>());
                    StartCoroutine(animWaitForHover(eventData.pointerDrag.gameObject, new Vector3(1.5f, 1, 1)));

                    eventData.pointerDrag.GetComponent<ThisCard>().lastParent = GameObject.Find("Player Asset Area").transform.name;
                    eventData.pointerDrag.transform.SetParent(GameObject.Find("Player Asset Area").transform);
                    //eventData.pointerDrag.transform.localScale = Vector3.one;
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

    IEnumerator animWaitForHover(GameObject it, Vector3 newScale)
    {
        Cursor.lockState = CursorLockMode.Locked;         //card anim
        Cursor.visible = false;                          //card anim

        //reset opacity
        GameObject.Find("Player Asset Area Parent").GetComponent<CanvasGroup>().alpha = 1f;
        GameObject.Find("Player Attack Area Parent").GetComponent<CanvasGroup>().alpha = 1f;
        GameObject.Find("Player Defense Area Parent").GetComponent<CanvasGroup>().alpha = 1f;


        LeanTween.scale(it, new Vector3(1.7f, 1.7f, 1.7f), 0);
        LeanTween.scale(it, newScale, 0.5f).setEase(LeanTweenType.easeOutElastic);
        yield return new WaitForSeconds(0.8f);
        it.GetComponent<CardHover>().originalScale = newScale;
        it.GetComponent<CardHover>().dropFinished = true;
        it.GetComponent<CardHover>().beingDragged = false;

        Cursor.lockState = CursorLockMode.None;         //card anim
        Cursor.visible = true;                          //card anim
    }

	void Update(){
		
	}
}
