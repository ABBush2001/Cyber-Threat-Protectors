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

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    private void Start()
    {
        originalScale = transform.localScale;
        Cursor.visible = true;
        dropFinished = false;
        beingDragged = false;
    }

    public void OnMouseEnter()
    {
       
        if (!isHovering && !dropFinished && !beingDragged)
        {
            isHovering = true;
            LeanTween.scale(this.gameObject, new Vector3(6f, 6f, 6f), 0.5f).setEase(LeanTweenType.easeOutCirc);
            LeanTween.moveLocalY(this.gameObject, 80, 0.5f);
            StartCoroutine(FadeOut());
        }
        else if(!isHovering && dropFinished)
        {
            isHovering = true;
            LeanTween.scale(this.gameObject, new Vector3(6f, 3.5f, 6f), 0.5f).setEase(LeanTweenType.easeOutCirc);
            StartCoroutine(FadeOut());
        }
    }

    public void OnMouseExit()
    {
        //Debug.Log("Mouse exit card");
        if (!beingDragged)
        {
            LeanTween.scale(this.gameObject, originalScale, 0.5f);
            LeanTween.moveLocalY(this.gameObject, 17, 0.5f);
            if(isHovering)
            {
                StartCoroutine(FadeIn());
            }
            isHovering = false;
        }
        else
        {
            LeanTween.scale(this.gameObject, originalScale, 0.5f);
            StartCoroutine(FadeIn());
            isHovering = false;
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
