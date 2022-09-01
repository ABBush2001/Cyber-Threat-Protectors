using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToPlay : MonoBehaviour
{
    public GameObject Hand;
	public GameObject It;

    public GameObject enemyPlayArea;
    private bool validCard;
    // Start is called before the first frame update
    void Start()
    {
        
        
        Hand = GameObject.Find("Enemy Play Area");
        It.SetActive(false);
        validCard = Hand.GetComponent<EnemyPlayArea>().checkDefenseEnemy(It);
        
        if(validCard){
            It.transform.SetParent(Hand.transform);
		It.transform.localScale = Vector3.one;
		It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
		It.transform.eulerAngles = new Vector3(25, 0, 0);
            It.SetActive(true);
            Debug.Log("Card ID being played: " + It.GetComponent<ThisCardEnemy>().thisId);
        }
        else{
            //It.GetComponent<Card>().addToDeck(false);
            Debug.Log("Card ID being sent to discard: " + It.GetComponent<ThisCardEnemy>().thisId);
            Destroy(It); //need to make it so it adds it back to the deck
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
