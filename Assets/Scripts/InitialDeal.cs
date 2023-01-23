using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script to deal the initial hand of cards*/
public class InitialDeal : MonoBehaviour
{
	public GameObject CardToHand;
	public GameObject CardToHandEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	IEnumerator StartGame()
	{
		for(int i = 0; i < 4; i++)
		{
			yield return new WaitForSeconds(1);
			Instantiate(CardToHand, transform.position, transform.rotation);
            Instantiate(CardToHandEnemy, transform.position, transform.rotation);

		}
	}
}
