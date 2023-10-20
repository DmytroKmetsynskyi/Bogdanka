using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoButton : MonoBehaviour
{
    public GameObject canvasInfo;
    public bool isOn = false;

    public void switch_()
    {
        isOn = !isOn;
    }

    private void FixedUpdate()
    {
        if (isOn)
        {
            canvasInfo.SetActive(true);
        }
        else
        {
            canvasInfo.SetActive(false);
        }
    }
}
