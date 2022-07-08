using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToPlayEnemy : MonoBehaviour
{
    public static GameObject Hand; 

    public static void MoveToPlay(GameObject It)
    {
        //reactivate title and description panels
        

        Hand = GameObject.Find("Enemy Play Area");
		It.transform.SetParent(Hand.transform);
		It.transform.localScale = Vector3.one;
		It.transform.position = new Vector3(Hand.transform.position.x, Hand.transform.position.y, -48);
		It.transform.eulerAngles = new Vector3(25, 0, 0);
    }

}
