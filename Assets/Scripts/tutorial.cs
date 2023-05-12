using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Sprite[] rulebook;
    public Image page;
    public int pos;
    
    // Start is called before the first frame update
    void Start()
    {
        page.sprite = rulebook[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rightArrowPressed(){
		if(pos < rulebook.Length-1){
            pos++;
        }
        
        page.sprite = rulebook[pos];
	}
	public void leftArrowPressed(){
        if(pos > 0){
            pos--;
        }
        page.sprite = rulebook[pos];
	}
}
