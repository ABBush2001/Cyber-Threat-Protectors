using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardHoverEnemy : MonoBehaviour
{
    //public GameObject enlargedCardPrefab;
    //private GameObject enlargedCardInstance;
    /*public Vector3 originalScale;
    private bool isHovering = false;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public GameObject blankCard;

    public bool forgotToPatchStarted = false;

    private void Start()
    {
        originalScale = transform.localScale;
        Cursor.visible = true;
    }

    public void OnMouseEnter()
    {
        //Debug.Log("Mouse over card");
        if (!isHovering && !forgotToPatchStarted && !blankCard.GetComponent<ForgotToPatchRemove>().discarded)
        {
            isHovering = true;
            LeanTween.scale(this.gameObject, new Vector3(3f, 3f, 3f), 0.5f);
        }
    }

    public void OnMouseExit()
    {
        if (!blankCard.GetComponent<ForgotToPatchRemove>().discarded)
        {
            LeanTween.scale(this.gameObject, originalScale, 0.5f);
            isHovering = false;
        }
    }*/

    public Vector3 originalScale;
    private bool isHovering = false;
    private bool colorChanged;
    private bool clickedOnce;

    public bool forgotToPatchStarted = false;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public GameObject blankCard;

    private void Start()
    {
        originalScale = new Vector3(1.5f, 1, 1);
        Cursor.visible = true;
        colorChanged = false;
        clickedOnce = false;
    }

    private void Update()
    {
        if (colorChanged)
        {
            if (Input.GetMouseButtonDown(0) && clickedOnce == false)
            {
                clickedOnce = true;
                if (!isHovering)
                {
                    Debug.Log("yo mama");
                    this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
                    isHovering = true;
                    LeanTween.scale(this.gameObject, new Vector3(6.5f, 4f, 6f), 0.5f).setEase(LeanTweenType.easeOutCirc);
                    StartCoroutine(FadeOut());
                }
            }
        }
    }

    public void OnMouseEnter()
    {
        if (forgotToPatchStarted && !blankCard.GetComponent<ForgotToPatchRemove>().discarded)
        {
            isHovering = true;
            LeanTween.scale(this.gameObject, new Vector3(3f, 3f, 3f), 0.5f);
        }
        else if (!colorChanged && !GameObject.Find("EventSystem").GetComponent<ForgotToPatch>().UIStarted)
        {
            this.gameObject.GetComponent<Image>().color = new Color(0, 255, 1);
            Debug.Log("Color Changed");
            colorChanged = true;
        }
    }

    public void OnMouseExit()
    {
        clickedOnce = false;
        this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
        LeanTween.scale(this.gameObject, originalScale, 0.5f);
        Debug.Log("Yo dada");
        if (isHovering)
        {
            StartCoroutine(FadeIn());
        }
        isHovering = false;
        colorChanged = false;

    }

    IEnumerator FadeOut()
    {
        //asset
        if (this.gameObject.GetComponent<ThisCardEnemy>().thisId >= 14 && this.gameObject.GetComponent<ThisCardEnemy>().thisId <= 18)
        {
            for (float i = 0; i < 0.5f; i += Time.deltaTime)
            {
                GameObject.Find("Enemy Attack Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                GameObject.Find("Enemy Defense Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                yield return null;
            }
        }
        //attack
        else if (this.gameObject.GetComponent<ThisCardEnemy>().thisId >= 4 && this.gameObject.GetComponent<ThisCardEnemy>().thisId <= 13)
        {
            for (float i = 0; i < 0.5f; i += Time.deltaTime)
            {
                GameObject.Find("Enemy Asset Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                GameObject.Find("Enemy Defense Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                yield return null;
            }
        }
        //defense
        else if (this.gameObject.GetComponent<ThisCardEnemy>().thisId >= 0 && this.gameObject.GetComponent<ThisCardEnemy>().thisId <= 3)
        {
            for (float i = 0; i < 0.5f; i += Time.deltaTime)
            {
                GameObject.Find("Enemy Attack Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                GameObject.Find("Enemy Asset Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0.1f, i / 0.5f);
                yield return null;
            }
        }
    }

    IEnumerator FadeIn()
    {
        //asset
        if (this.gameObject.GetComponent<ThisCardEnemy>().thisId >= 14 && this.gameObject.GetComponent<ThisCardEnemy>().thisId <= 18)
        {
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                GameObject.Find("Enemy Attack Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                GameObject.Find("Enemy Defense Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1f, i / 0.5f);
                yield return null;
            }
        }
        //attack
        else if (this.gameObject.GetComponent<ThisCardEnemy>().thisId >= 4 && this.gameObject.GetComponent<ThisCardEnemy>().thisId <= 13)
        {
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                GameObject.Find("Enemy Asset Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                GameObject.Find("Enemy Defense Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1f, i / 0.5f);
                yield return null;
            }
        }
        //defense
        else if (this.gameObject.GetComponent<ThisCardEnemy>().thisId >= 0 && this.gameObject.GetComponent<ThisCardEnemy>().thisId <= 3)
        {
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                GameObject.Find("Enemy Asset Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                GameObject.Find("Enemy Attack Area").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.1f, 1, i / 0.5f);
                yield return null;
            }
        }
    }
}