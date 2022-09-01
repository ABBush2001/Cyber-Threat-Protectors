using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardArea : MonoBehaviour
{
    public GameObject playArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void checkForDefense(){
        //check if defense type card is already in play
        int numOfDefense = 0;
        //goes through each card in hand
        foreach(Transform child in transform){
            //if it has a defense id for through another check
            if(child.GetComponent<ThisCard>().thisId >= 0 && child.GetComponent<ThisCard>().thisId <= 3)
            {
                //Debug.Log("defense card found");
                numOfDefense++;
                child.GetComponent<Drag>().enabled = true;
                //if there is already a card on the field with the same id, disable the card from being played
                foreach(Transform playAreaChild in playArea.transform){
                    if(child.GetComponent<ThisCard>().thisId == playAreaChild.GetComponent<ThisCard>().thisId){
                        child.GetComponent<Drag>().enabled = false;
                    }
                }
            }
        }
        //Debug.Log("num of defense cards in hand: " + numOfDefense);
    }
}
