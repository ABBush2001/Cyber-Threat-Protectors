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
        dropFinished = true;
        beingDragged = false;
    }

    public void OnMouseEnter()
    {
        //Debug.Log("Mouse over card");
        if (!isHovering && dropFinished && !beingDragged)
        {
            isHovering = true;
            LeanTween.scale(this.gameObject, new Vector3(6f, 6f, 6f), 0.5f).setEase(LeanTweenType.easeOutCirc);
            LeanTween.moveLocalY(this.gameObject, 80, 0.5f);
            Debug.Log(originalScale);
            /*enlargedCardInstance = Instantiate(enlargedCardPrefab, transform.position + Vector3.up * 230.5f, Quaternion.identity);
            enlargedCardInstance.transform.localScale = originalScale * 5.0f;
            enlargedCardInstance.GetComponent<cardHoverInfo>().cardName = "" + GetComponent<ThisCard>().cardName;
            enlargedCardInstance.GetComponent<cardHoverInfo>().cardDesc = "" + GetComponent<ThisCard>().cardDesc;
            enlargedCardInstance.GetComponent<Image>().sprite = GetComponent<Image>().sprite;*/
        }
        else if(!isHovering && dropFinished)
        {
            isHovering = true;
            LeanTween.scale(this.gameObject, new Vector3(6f, 6f, 6f), 0.5f).setEase(LeanTweenType.easeOutCirc);
        }
    }

    public void OnMouseExit()
    {
        //Debug.Log("Mouse exit card");
        if (!beingDragged)
        {
            LeanTween.scale(this.gameObject, originalScale, 0.5f);
            LeanTween.moveLocalY(this.gameObject, 17, 0.5f);
            isHovering = false;
        }
        else
        {
            LeanTween.scale(this.gameObject, originalScale, 0.5f);
            isHovering = false;
        }
        /*if (enlargedCardInstance != null)
        {
            isHovering = false;
            Destroy(enlargedCardInstance);
        }*/
    }
}