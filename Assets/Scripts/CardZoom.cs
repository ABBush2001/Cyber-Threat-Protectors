using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject cardArea;

    private GameObject zoomCard;
    public Transform parentToReturnTo = null;
    // Start is called before the first frame update
    void Awake()
    {
        Canvas = GameObject.Find("Canvas");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHoverEnter(){
        parentToReturnTo = this.transform.parent;
        parentToReturnTo.GetComponent<HorizontalLayoutGroup>().enabled = false;
        //this.transform.SetParent(this.transform.parent.parent);
        zoomCard = Instantiate(this.gameObject, new Vector2(250, 250), Quaternion.identity, this.transform.parent.parent);

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        
        rect.sizeDelta = new Vector2(240, 344);
        zoomCard.GetComponent<Image>().raycastTarget = false;
        
    }

    public void OnHoverExit(){
        Destroy(zoomCard);
        parentToReturnTo.GetComponent<HorizontalLayoutGroup>().enabled = true;
        //this.transform.SetParent(parentToReturnTo);
    }
}
    // public GameObject Canvas;
    // public GameObject card1;
    // public Transform parentToReturnTo = null;
 
    // Vector2 temp;
    
    // public void Awake()
    // {
    //     Canvas = GameObject.Find("Canvas");
    // }

    
    // public void OnHoverEnter()
    // {
        
    //     temp = card1.transform.localScale;

    //     temp.x = temp.x * 2f;
    //     temp.y = temp.y * 2f;

    //     card1.transform.localScale = temp;
    //     parentToReturnTo = card1.transform.parent;
    //     card1.transform.SetParent(card1.transform.parent.parent);
    //     //card1.layer = 7;

    // }

    // public void OnHoverExit()
    // {
    //     card1.transform.localScale = new Vector2(1,1);
    //     card1.transform.Translate(0, 0, 0);
    //     card1.transform.SetParent(parentToReturnTo);
    // }
