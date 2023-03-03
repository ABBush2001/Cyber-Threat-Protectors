using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*script that ensures that when a card is instantiated, it is a child of the player card area panel*/
public class CardToHand : MonoBehaviour
{
	public GameObject Hand;
	public GameObject It;

    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Player Card Area");
		It.transform.SetParent(Hand.transform);
        It.GetComponent<ThisCard>().lastParent = Hand.transform.name;
		It.transform.localScale = Vector3.one;
		It.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		It.transform.eulerAngles = new Vector3(25, 0, 0);
        Hand.transform.GetComponent<PlayerCardArea>().checkForDefense();

        StartCoroutine(addSprite());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator addSprite()
    {
        yield return new WaitForSeconds(0.001f);
        It.gameObject.GetComponent<Image>().sprite = GameObject.Find("ImageManager").GetComponent<ImageList>().sprites[It.GetComponent<ThisCard>().thisId];
    }
}
