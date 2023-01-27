using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForgotToPatchDestroy : MonoBehaviour, IPointerDownHandler
{
    public bool secTrain = false;

    public void OnPointerDown(PointerEventData eventData)
    {
       

        //if security training in play
        if (this.gameObject.GetComponent<ThisCardEnemy>().thisId == 3)
        {
            if (GameObject.Find("Forgot To Patch Canvas").activeSelf)
            {
                Debug.Log(this.gameObject.name + "was destroyed by forgot to patch");
                Destroy(this.gameObject);
                GameObject.Find("Forgot To Patch Canvas").SetActive(false);
                secTrain = false;
            }
        }
        //else, delete two cards
        else if(GameObject.Find("Forgot To Patch Canvas").activeSelf)
        {
            if(GameObject.Find("Enemy Play Area").transform.GetComponentInChildren<ThisCardEnemy>().thisId == 3)
            {

            }
            else
            {
                Debug.Log(this.gameObject.name + "forgot to patch: select 2 cards");
                Destroy(this.gameObject);
                GameObject.Find("EventSystem").GetComponent<ForgotToPatch>().j++;

                if (GameObject.Find("EventSystem").GetComponent<ForgotToPatch>().j >= 2)
                {
                    if (GameObject.Find("Forgot To Patch Canvas").activeSelf)
                    {
                        GameObject.Find("Forgot To Patch Canvas").SetActive(false);
                        GameObject.Find("EventSystem").GetComponent<ForgotToPatch>().j = 0;
                    }
                }
            }
            
        }
            
    }
}
