using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*Script that allows card objects to be dragged around*/
public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{	
    private RectTransform rectTransform;
	private CanvasGroup canvasGroup;
	public bool isDraggable = true;


	public Transform parentToReturnTo = null;
	
	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		if(isDraggable)
		{
			canvasGroup.blocksRaycasts = false;

			//trying to fix drag/drop
			parentToReturnTo = this.transform.parent;
			this.transform.SetParent(this.transform.parent.parent );
		}
		
	}
	
	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;
		//
		//this.transform.SetParent(parentToReturnTo);
	}
	
	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta;
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		
	}
}
