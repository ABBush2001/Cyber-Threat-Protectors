using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardwareFailure : MonoBehaviour
{

    public GameObject hardwareScreen;

    public void StartUI()
    {
        hardwareScreen.SetActive(true);
    }

    void Update()
    {
        if(hardwareScreen)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.GetComponent<ThisCard>().thisId >= 14 && hit.transform.GetComponent<ThisCard>().thisId <= 18)
                    {
                        Destroy(hit.transform.gameObject);
                        hardwareScreen.SetActive(false);
                    }
                }
            }
        }
    }

}