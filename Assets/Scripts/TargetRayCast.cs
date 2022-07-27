using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray raycastPosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition.origin, raycastPosition.direction, Mathf.Infinity);

            
            if(hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log(hit.collider.bounds);
                hit.collider.gameObject.GetComponent<Card>().MoveToDiscardPile();
				//hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				//myTarget.GetComponent<Card>().MoveToDiscardPile();

            }
        }
    }
}
