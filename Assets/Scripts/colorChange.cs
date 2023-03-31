using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorChange : MonoBehaviour
{
    public Image bg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bg.color =  Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));
        
    }
}
