using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ForgotToPatch : MonoBehaviour
{
    public GameObject forgotToPatchScreen;
    public GameObject enemyHand;

    public int j = 0;

    public GameObject enemyDefensePanel;

    public bool UIStarted;

    public int count;

    private Vector3[] positions = new Vector3[5];
    private Vector3[] positionsPanels = new Vector3[4];

    private void Start()
    {
        count = 0;
        UIStarted = false;
    }

    public void StartUI()
    {
        for(int i = 0; i < enemyDefensePanel.transform.childCount; i++)
        {
            if(enemyDefensePanel.transform.GetChild(i).GetComponent<ThisCardEnemy>().thisId == 3)
            {
                Destroy(enemyDefensePanel.transform.GetChild(i).gameObject);
                return;
            }
        }

        forgotToPatchScreen.SetActive(true);

        int tmp = 1000;

        for(int j = enemyHand.transform.childCount-1; j >= 0; j--)
        {
            positions[j] = enemyHand.transform.GetChild(j).transform.position;
            LeanTween.moveLocal(enemyHand.transform.GetChild(j).gameObject, new Vector3(tmp, 40, 0), 1);
            StartCoroutine(FadeOut());
            tmp += 150;
        }

        UIStarted = true;

        
    }

    private void Update()
    {
        if(count == 2)
        {
            count = 0;

            //call to close pop up, return cards and go back to game as normal
            forgotToPatchScreen.SetActive(false);
            for(int i = enemyHand.transform.childCount - 1; i >= 0; i--)
            {
                LeanTween.move(enemyHand.transform.GetChild(i).gameObject, positions[i], 1);
            }
            StartCoroutine(FadeIn());

            UIStarted = false;
        }
    }

    IEnumerator FadeOut()
    {
        positionsPanels[0] = GameObject.Find("Enemy Asset Area").transform.position;
        positionsPanels[1] = GameObject.Find("Enemy Attack Area").transform.position;
        positionsPanels[2] = GameObject.Find("Enemy Defense Area").transform.position;

        LeanTween.moveLocal(GameObject.Find("Enemy Asset Area"), new Vector3(4000, 0, 0), 0.005f);
        LeanTween.moveLocal(GameObject.Find("Enemy Attack Area"), new Vector3(4000, 0, 0), 0.005f);
        LeanTween.moveLocal(GameObject.Find("Enemy Defense Area"), new Vector3(4000, 0, 0), 0.005f);

        yield return null;
    }

    IEnumerator FadeIn()
    {
        LeanTween.move(GameObject.Find("Enemy Asset Area"), positionsPanels[0], 0.005f);
        LeanTween.move(GameObject.Find("Enemy Attack Area"), positionsPanels[1], 0.005f);
        LeanTween.move(GameObject.Find("Enemy Defense Area"), positionsPanels[2], 0.005f);

        yield return null;

        for(int j = 3; j >= 0; j--)
        {
            enemyHand.transform.GetChild(j).GetComponent<CanvasGroup>().alpha = 1;
        }
    }

}
