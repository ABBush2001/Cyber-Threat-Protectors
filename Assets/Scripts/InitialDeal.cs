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
        Cursor.lockState = CursorLockMode.Locked;       //for card anim
        Cursor.visible = false;                         //card anim

        for (int i = 0; i < 4; i++)
		{
			yield return new WaitForSeconds(1);
			GameObject card = Instantiate(CardToHand, transform.position, transform.rotation);
            GameObject enemyCard = Instantiate(CardToHandEnemy, transform.position, transform.rotation);

            Debug.Log("Working");

            
        }

        Cursor.lockState = CursorLockMode.None;         //card anim
        Cursor.visible = true;                          //card anim
    }
}
