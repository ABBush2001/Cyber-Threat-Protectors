using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRayCast : MonoBehaviour
{
    public bool targetOn;
    // Start is called before the first frame update
    void Start()
    {
        targetOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetOn){
            if(Input.GetMouseButtonDown(0))
            {
            Ray raycastPosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition.origin, raycastPosition.direction, Mathf.Infinity);

                if(hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<Card>().MoveToDiscardPile();
                    Debug.Log(hit.collider.gameObject.name);
                    targetOn = false;
				//hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				//myTarget.GetComponent<Card>().MoveToDiscardPile();

                }
            }
        }
        
    }
}
