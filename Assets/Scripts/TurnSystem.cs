using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{

    public bool isYourTurn;
    public int yourTurn;
    public int enemyTurn;
    public TextMeshProUGUI turnText;

    public int playerMaxPoints;
    public int playerCurPoints;
    public Text playerPointText;

    public int enemyMaxPoints;
    public int enemyCurPoints;
    public Text enemyPointText;

    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        enemyTurn = 0;

        playerMaxPoints = 20;
        enemyMaxPoints = 20;
        playerCurPoints = 0;
        enemyCurPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn == true)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Opponent Turn";
        }
    }

    public void PlayerEndTurn()
    {
        isYourTurn = false;
        enemyTurn += 1; 
    }

    public void EnemyEndTurn()
    {
        isYourTurn = true;
        yourTurn += 1;
    }
}