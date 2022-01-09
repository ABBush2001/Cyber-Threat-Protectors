using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{

    public List<Card> cList = new List<Card>();
    public int thisId;

    public string cardName;
    public string cardDesc;

    public Text nameText;
    public Text descriptionText;

    public bool cardBack;
    public static bool staticCardBack;

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = UnityEngine.Random.Range(0, 3);
        thisId = randomNumber;
        CardDatabase.fillList(cList);

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            staticCardBack = cardBack;
        }
        catch(NullReferenceException e)
        {

        }
        

        cardDesc = cList[thisId].cardDesc;
        cardName = cList[thisId].cardName;


        nameText.text = "" + cardName;
        descriptionText.text = "" + cardDesc;

        
    }
}
