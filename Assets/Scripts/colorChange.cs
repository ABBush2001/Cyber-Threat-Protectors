using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorChange : MonoBehaviour
{
    public Image materialToChange;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     bg.color =  Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));
        
    // }

    public float duration;
    //public Material materialToChange;
    public Color targetColor = new Color(0,1,0,1);
    public Color targetColor2 = new Color(0,1,0,1);
    void Start()
    {
        //materialToChange = gameObject.GetComponent<Renderer>().material;
        StartCoroutine(LerpFunction(Color.blue, duration));
    }
    IEnumerator LerpFunction(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = materialToChange.color;
        while (time < duration)
        {
            materialToChange.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        materialToChange.color = endValue;
        StartCoroutine(LerpFunction2(Color.red, duration));
    }

    IEnumerator LerpFunction2(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = materialToChange.color;
        while (time < duration)
        {
            materialToChange.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        materialToChange.color = endValue;
        StartCoroutine(LerpFunction(Color.blue, duration));
    }
}
