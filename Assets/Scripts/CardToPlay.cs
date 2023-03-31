using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardToPlay : MonoBehaviour
{
    public GameObject Hand;
	public GameObject It;

    public GameObject enemyPlayArea;
    private bool validCard;
    private ThisCardEnemy enemyCard;
    // Start is called before the first frame update
    void Start()
    {
        
        enemyCard = It.GetComponent<ThisCardEnemy>();

        //set hand based on card type
        if(enemyCard.thisId >= 0 && enemyCard.thisId <= 3)
        {
            Hand = GameObject.Find("Enemy Defense Area");
        }
        else if(enemyCard.thisId >= 4 && enemyCard.thisId <= 13)
        {
            Hand = GameObject.Find("Enemy Attack Area");
        }
        else if(enemyCard.thisId >= 14 && enemyCard.thisId <= 18)
        {
            Hand = GameObject.Find("Enemy Asset Area");
        }
        else
        {
            Hand = GameObject.Find("Enemy Attack Area");
        }
        
        It.SetActive(false);
        validCard = Hand.GetComponent<EnemyPlayArea>().checkDefenseEnemy(It);
        
        if(validCard){
            LeanTween.scale(It, new Vector3(1.7f, 1.7f, 1.7f), 0);
            LeanTween.scale(It, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeOutElastic);

            It.transform.SetParent(Hand.transform);
		    It.transform.localScale = Vector3.one;
		    It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
		    It.transform.eulerAngles = new Vector3(25, 0, 0);
            It.SetActive(true);
            StartCoroutine(addSprite());
            //Debug.Log("Card ID being played: " + It.GetComponent<ThisCardEnemy>().thisId);
        }
        else{
            //It.GetComponent<Card>().addToDeck(false);
            //Debug.Log("Card ID being sent to discard: " + It.GetComponent<ThisCardEnemy>().thisId);
            Deck.staticEnemyDeck.Add(new Card(enemyCard.thisId, enemyCard.cardTypeID, enemyCard.cardName, enemyCard.cardDamage,
             enemyCard.cardPoints, enemyCard.cardDefense, enemyCard.cardDesc, enemyCard.numberOfCardsInDeck));
            Destroy(It); //need to make it so it adds it back to the deck
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator addSprite()
    {
        yield return new WaitForSeconds(0.001f);
        It.gameObject.GetComponent<Image>().sprite = GameObject.Find("ImageManager").GetComponent<ImageList>().sprites[It.GetComponent<ThisCardEnemy>().thisId];
    }

}
