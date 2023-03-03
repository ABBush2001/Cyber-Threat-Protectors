using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardHover : MonoBehaviour
{
    public GameObject enlargedCardPrefab;
    private GameObject enlargedCardInstance;
    private Vector3 originalScale;
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
        if (enlargedCardPrefab != null && !isHovering)
        {
            isHovering = true;
            enlargedCardInstance = Instantiate(enlargedCardPrefab, transform.position + Vector3.up * 230.5f, Quaternion.identity);
            enlargedCardInstance.transform.localScale = originalScale * 5.0f;
            enlargedCardInstance.GetComponent<cardHoverInfo>().cardName = "" + GetComponent<ThisCard>().cardName;
            enlargedCardInstance.GetComponent<cardHoverInfo>().cardDesc = "" + GetComponent<ThisCard>().cardDesc;
            enlargedCardInstance.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        }
    }

    public void OnMouseExit()
    {
        //Debug.Log("Mouse exit card");
        if (enlargedCardInstance != null)
        {
            isHovering = false;
            Destroy(enlargedCardInstance);
        }
    }
}