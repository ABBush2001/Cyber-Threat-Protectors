using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*script that ensures that when a card is instantiated, it is a child of the player card area panel*/
public class CardToHandEnemy : MonoBehaviour
{
	public GameObject Hand;
	public GameObject It;

    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Enemy Card Area");
		It.transform.SetParent(Hand.transform);
		It.transform.localScale = Vector3.one;
		It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
		It.transform.eulerAngles = new Vector3(25, 0, 0);
        LeanTween.scale(It, new Vector3(1.7f, 1.7f, 1.7f), 0);
        LeanTween.scale(It, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeOutBounce);

        StartCoroutine(addSprite());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator addSprite()
    {
        yield return new WaitForSeconds(0.001f);
        It.gameObject.GetComponent<Image>().sprite = GameObject.Find("ImageManager").GetComponent<ImageList>().sprites[21];
    }
}
