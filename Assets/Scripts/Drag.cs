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

	private Vector2 offset;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (isDraggable)
		{
			LeanTween.scale(this.gameObject, new Vector3(1.7f, 1.7f, 1.7f), 0);


			canvasGroup.blocksRaycasts = false;

			this.gameObject.GetComponent<CardHover>().beingDragged = true;
			parentToReturnTo = this.transform.parent;
			this.transform.SetParent(this.transform.parent.parent);
			
			// Calculate the offset between the object's position and the cursor's position
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out offset);
			offset = rectTransform.anchoredPosition - offset;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;
		this.gameObject.GetComponent<CardHover>().beingDragged = false;
		this.transform.SetParent(parentToReturnTo);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (isDraggable)
		{
			Vector2 localPoint;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out localPoint))
			{
				rectTransform.anchoredPosition = localPoint + offset;
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		// Handle pointer down event if needed
	}
}
