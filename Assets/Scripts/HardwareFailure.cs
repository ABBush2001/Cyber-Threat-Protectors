using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HardwareFailure : MonoBehaviour
{

    public GameObject hardwareScreen;

    public void StartUI()
    {
        hardwareScreen.SetActive(true);
    }

}