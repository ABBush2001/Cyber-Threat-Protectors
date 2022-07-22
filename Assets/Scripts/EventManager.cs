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
    private Card card;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        discardPileText.text = discardPile.Count.ToString();
        
    }

}
