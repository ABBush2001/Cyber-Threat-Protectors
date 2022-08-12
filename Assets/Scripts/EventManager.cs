using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class EventManager : MonoBehaviour
{
    public List<Card> discardPile = new List<Card>();
    public TextMeshProUGUI discardPileText;
    // Start is called before the first frame update
    public bool targetOn;
    public Card card;

    public GameObject playArea;
    public GameObject playAreaEnemy;
    void Start()
    {
        targetOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*discardPileText.text = discardPile.Count.ToString();
            if(targetOn){
                if(Input.GetMouseButtonDown(0))
                {
                Ray raycastPosition = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(raycastPosition.origin, raycastPosition.direction, Mathf.Infinity,256);

                    if(hit.collider != null)
                    {
                        //hit.collider.gameObject.GetComponent<Card>().MoveToDiscardPile();
                        card.myTarget = hit.collider;
                        Debug.Log(hit.collider.gameObject.name);
                        targetOn = false;
                    //hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    //myTarget.GetComponent<Card>().MoveToDiscardPile();

                    }
                    else{
                        card.myTarget = null;
                    }
                }
            }
        
        
        */
    }

}
