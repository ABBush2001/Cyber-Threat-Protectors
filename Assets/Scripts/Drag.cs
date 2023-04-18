using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

/*Script that allows card objects to be dragged around*/
public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{	
    private RectTransform rectTransform;
	private CanvasGroup canvasGroup;
	public bool isDraggable = true;

	[SerializeField] private Canvas canvas;

	public Transform parentToReturnTo = null;


	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		
	}
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		if(isDraggable)
		{
			canvasGroup.blocksRaycasts = false;

			

			this.gameObject.GetComponent<CardHover>().beingDragged = true;
			parentToReturnTo = this.transform.parent;
			this.transform.SetParent(this.transform.parent.parent );
			Debug.Log("this drag");
			LeanTween.scale(this.gameObject, new Vector3(1.7f, 1.7f, 1.7f), 0.05f).setEase(LeanTweenType.easeOutElastic);
		}
		
	}
	
	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;
        this.gameObject.GetComponent<CardHover>().beingDragged = false;
        //
        //this.transform.SetParent(parentToReturnTo);
    }
	
	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		
	}
}
