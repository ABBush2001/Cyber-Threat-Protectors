using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardZoomInstan : MonoBehaviour
{
	public GameObject Hand;
	public GameObject It;
	
    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Canvas");
		It.transform.SetParent(Hand.transform);
        //It.transform.position= new Vector3(100, 400, 0);
    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
