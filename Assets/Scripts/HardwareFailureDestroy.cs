using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HardwareFailureDestroy : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {

        if(this.gameObject.GetComponent<ThisCardEnemy>().thisId >= 14 && this.gameObject.GetComponent<ThisCardEnemy>().thisId <= 18)
        {
            if (GameObject.Find("Hardware Failure Canvas").activeSelf == true)
            {
                Debug.Log(this.gameObject.name + "was destroyed");
                Destroy(this.gameObject);
                GameObject.Find("Hardware Failure Canvas").SetActive(false);
            }
        }
        
    }
}
