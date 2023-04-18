using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardHoverEnemy : MonoBehaviour
{
    //public GameObject enlargedCardPrefab;
    //private GameObject enlargedCardInstance;
    public Vector3 originalScale;
    private bool isHovering = false;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    private void Start()
    {
        originalScale = transform.localScale;
        Cursor.visible = true;
    }

    public void OnMouseEnter()
    {
        //Debug.Log("Mouse over card");
        if (!isHovering)
        {
            isHovering = true;
            LeanTween.scale(this.gameObject, new Vector3(3f, 3f, 3f), 0.5f);
            /*enlargedCardInstance = Instantiate(enlargedCardPrefab, transform.position + Vector3.down * 230.5f, Quaternion.identity);
            enlargedCardInstance.transform.localScale = originalScale * 5.0f;
            enlargedCardInstance.GetComponent<cardHoverInfo>().cardName = "" + GetComponent<ThisCardEnemy>().cardName;
            enlargedCardInstance.GetComponent<cardHoverInfo>().cardDesc = "" + GetComponent<ThisCardEnemy>().cardDesc;
            enlargedCardInstance.GetComponent<Image>().sprite = GetComponent<Image>().sprite;*/
        }
    }

    public void OnMouseExit()
    {
        //Debug.Log("Mouse exit card");
        LeanTween.scale(this.gameObject, originalScale, 0.5f);
        isHovering=false;
        /*if (enlargedCardInstance != null)
        {
            isHovering = false;
            Destroy(enlargedCardInstance);
        }*/
    }
}