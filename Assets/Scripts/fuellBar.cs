using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuellBar : MonoBehaviour
{
    public Image fuelImage;
    public RocketController RocketController;

    private void FixedUpdate()
    {
        float fuell = 0;
        float sfuell = 0;

        if (RocketController.remoteRocket)
        {
            fuell = GameObject.Find("RocketRemote(Clone)").GetComponent<homingMissle_remote>().fuell;
            sfuell = GameObject.Find("RocketRemote(Clone)").GetComponent<homingMissle_remote>().sfuell;
        }
        else
        {
            fuell = GameObject.Find("Rocket(Clone)").GetComponent<homingMissle>().fuell;
            sfuell = GameObject.Find("Rocket(Clone)").GetComponent<homingMissle>().sfuell;
        }
        
        fuelImage.fillAmount = fuell / sfuell;
    }
}
