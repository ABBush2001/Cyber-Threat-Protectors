using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardHover : MonoBehaviour
{
    public GameObject enlargedCardPrefab;
    private GameObject enlargedCardInstance;
    public Vector3 originalScale;
    private bool isHovering = false;
    public bool dropFinished;
    public bool beingDragged;
    private bool colorChanged;
    private bool clickedOnce;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    private void Start()
    {
        originalScale = transform.localScale;
        Cursor.visible = true;
        dropFinished = false;
        beingDragged = false;
        colorChanged = false;
        clickedOnce = false;
    }

    private void Update()
    {
        if(colorChanged)
        {
            if(Input.GetMouseButtonDown(0) && clickedOnce == false)
            {
                clickedOnce = true;
                if (!isHovering && !dropFinished && !beingDragged)
                {
                    this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
                    isHovering = true;
                    LeanTween.scale(this.gameObject, new Vector3(10f, 10f, 10f), 0.5f).setEase(LeanTweenType.easeOutCirc);
                    LeanTween.moveLocalY(this.gameObject, 100, 0.5f);
                    StartCoroutine(FadeOut());
                }
                else if (!isHovering && dropFinished)
                {
                    this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
                    isHovering = true;
                    LeanTween.scale(this.gameObject, new Vector3(15f, 10f, 10f), 0.5f).setEase(LeanTweenType.easeOutCirc);

                    //asset
                    if(this.gameObject.GetComponent<ThisCard>().thisId > 13 && this.gameObject.GetComponent<ThisCard>().thisId < 19)
                    {
                        LeanTween.moveLocalY(this.gameObject, 80, 0.5f);    
                    }
                    //defense
                    else if(this.gameObject.GetComponent<ThisCard>().thisId < 4)
                    {
                        LeanTween.moveLocalY(this.gameObject, 50, 0.5f);
                    }


                    StartCoroutine(FadeOut());
                }
            }
        }
    }

    public void OnMouseEnter()
    {
        if (!colorChanged)
        {
            this.gameObject.GetComponent<Image>().color = new Color(0, 255, 1);
            colorChanged = true;
        }
    }

    public void OnMouseExit()
    {
        //Debug.Log("Mouse exit card");
        if (!beingDragged)
        {
            clickedOnce = false;
            this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
            LeanTween.scale(this.gameObject, originalScale, 0.5f);
            LeanTween.moveLocalY(this.gameObject, 17, 0.5f);
            if(isHovering)
            {
                StartCoroutine(FadeIn());
            }
            isHovering = false;
            colorChanged = false;
            
        }
        else
        {
            clickedOnce = false;
            this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
            LeanTween.scale(this.gameObject, originalScale, 0.5f);
            StartCoroutine(FadeIn());
            isHovering = false;
            colorChanged = false;
        }
        
    }

    IEnumerator FadeOut()
    {
        //if in card area
        if (!dropFinished)
        {
            for (float i = 0; i < 0.5f; i += Time.deltaTime)
            {
                GameObject.Find("Player Asset Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                GameObject.Find("Player Attack Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                GameObject.Find("Player Defense Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                yield return null;
            }
        }
        else
        {
            //if attack card
            if(this.gameObject.GetComponent<ThisCard>().thisId >= 4 && this.gameObject.GetComponent<ThisCard>().thisId <= 13)
            {
                for (float i = 0; i < 0.5f; i += Time.deltaTime)
                {
                    GameObject.Find("Player Asset Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                    GameObject.Find("Player Defense Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                    yield return null;
                }
            }
            //if defense card
            else if (this.gameObject.GetComponent<ThisCard>().thisId >= 0 && this.gameObject.GetComponent<ThisCard>().thisId <= 3)
            {
                for (float i = 0; i < 0.5f; i += Time.deltaTime)
                {
                    GameObject.Find("Player Asset Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                    GameObject.Find("Player Attack Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                    yield return null;
                }
            }
            //if asset card
            else if (this.gameObject.GetComponent<ThisCard>().thisId >= 14 && this.gameObject.GetComponent<ThisCard>().thisId <= 18)
            {
                for (float i = 0; i < 0.5f; i += Time.deltaTime)
                {
                    GameObject.Find("Player Attack Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                    GameObject.Find("Player Defense Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                    yield return null;
                }
            }
        }
    }

    IEnumerator FadeIn()
    {
        if (!dropFinished)
        {
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                GameObject.Find("Player Asset Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                GameObject.Find("Player Attack Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                GameObject.Find("Player Defense Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1f, i / 0.5f);
                yield return null;
            }
        }
        else
        {
            //if attack card
            if (this.gameObject.GetComponent<ThisCard>().thisId >= 4 && this.gameObject.GetComponent<ThisCard>().thisId <= 13)
            {
                for (float i = 0; i < 0.5f; i += Time.deltaTime)
                {
                    GameObject.Find("Player Asset Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                    GameObject.Find("Player Defense Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                    yield return null;
                }
            }
            //if defense card
            else if (this.gameObject.GetComponent<ThisCard>().thisId >= 0 && this.gameObject.GetComponent<ThisCard>().thisId <= 3)
            {
                for (float i = 0; i < 0.5f; i += Time.deltaTime)
                {
                    GameObject.Find("Player Asset Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                    GameObject.Find("Player Attack Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                    yield return null;
                }
            }
            //if asset card
            else if (this.gameObject.GetComponent<ThisCard>().thisId >= 14 && this.gameObject.GetComponent<ThisCard>().thisId <= 18)
            {
                for (float i = 0; i < 0.5f; i += Time.deltaTime)
                {
                    GameObject.Find("Player Attack Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                    GameObject.Find("Player Defense Area Parent").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                    yield return null;
                }
            }
        }
    }
}
