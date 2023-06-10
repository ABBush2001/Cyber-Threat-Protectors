using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgotToPatchRemove : MonoBehaviour
{
    public GameObject enemyCard;
    public GameObject enemyHand;
    public GameObject eventSystem;

    private bool isHovering;
    public bool discarded;

    private void Start()
    {
        discarded = false;
        isHovering = false;
        enemyHand = GameObject.Find("Enemy Card Area");
        eventSystem = GameObject.Find("EventSystem");
    }

    private void Update()
    {
        if(isHovering && Input.GetMouseButtonDown(0))
        {
            discarded = true;
            this.GetComponent<CanvasGroup>().alpha = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //set blank to not active
            //spawn in next card from deck, do animation to show the card
            //After two have been eliminated, send back to hand and close UI
            GameObject newCard = Instantiate(enemyCard, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Quaternion());
            newCard.GetComponent<CardHoverEnemy>().blankCard = this.gameObject;
            newCard.transform.SetParent(GameObject.Find("Canvas").transform);
            Vector3 diff = new Vector3(1, 1, 1);
            newCard.transform.localScale += (diff - newCard.transform.localScale);

            LeanTween.scale(newCard, new Vector3(2, 2, 2), 0.5f);
            StartCoroutine(FadeOut(newCard.gameObject));
        }
    }

    public void OnMouseEnter()
    {

        if(GameObject.Find("EventSystem").GetComponent<ForgotToPatch>().UIStarted)
        {
            Debug.Log("Card hovered over");
            this.gameObject.GetComponent<Image>().color = new Color(0, 255, 1);
            isHovering = true;
        }
    }

    public void OnMouseExit()
    {
        Debug.Log("Card hovered over");
        this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
        isHovering = false;
    }

    IEnumerator FadeOut(GameObject it)
    {
        yield return new WaitForSeconds(2);

        for (float i = 0; i < 0.5f; i += Time.deltaTime)
        {
            it.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, i / 0.5f);
            yield return null;
        }

        if(it.name == "FakeCard(Clone)")
        {
            Destroy(it);
        }

        eventSystem.GetComponent<ForgotToPatch>().count++;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
