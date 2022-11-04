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
        if (secTrain == true && this.gameObject.GetComponent<ThisCardEnemy>().thisId == 3)
        {
            if (GameObject.Find("Forgot To Patch Canvas"))
            {
                Debug.Log(this.gameObject.name);
                Destroy(this.gameObject);
                GameObject.Find("Forgot To Patch Canvas").SetActive(false);
            }
        }
        //else, delete two cards
        else
        {
            if(secTrain == false)
            {
                Debug.Log(this.gameObject.name);
                Destroy(this.gameObject);
                GameObject.Find("EventSystem").GetComponent<ForgotToPatch>().j++;

                if (GameObject.Find("EventSystem").GetComponent<ForgotToPatch>().j == 2)
                {
                    if (GameObject.Find("Forgot To Patch Canvas"))
                    {
                        GameObject.Find("Forgot To Patch Canvas").SetActive(false);
                        GameObject.Find("EventSystem").GetComponent<ForgotToPatch>().j = 0;
                    }
                }
            }
            
        }
    }
}
