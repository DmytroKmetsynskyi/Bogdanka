using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class paramsOfMissle : MonoBehaviour
{
    public ManagerOfMissle ManagerOfMissle;

    public TMP_InputField speedI;
    public TMP_Text speedP;
    
    public TMP_InputField accelerationI;
    public TMP_Text accelerationP;

    public TMP_InputField timeI;
    public TMP_Text timeP;
    
    public TMP_InputField radiusOPI;
    public TMP_Text radiusOPP;
    
    public TMP_InputField radiusAI;
    public TMP_Text radiusAIP;
    
    public TMP_InputField rotationI;
    public TMP_Text rotationP;


    public Toggle Toggle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        speedP.text = ManagerOfMissle.speedOfMissle.ToString();
        accelerationP.text = ManagerOfMissle.accelerationOfMissle.ToString();
        timeP.text = ManagerOfMissle.timeOfPointing.ToString();
        radiusOPP.text = ManagerOfMissle.operatorRange.ToString();
        radiusAIP.text = ManagerOfMissle.automaticRange.ToString();

        rotationP.text = ManagerOfMissle.rotationOfMissle.ToString();

        Toggle.isOn = ManagerOfMissle.isRemote;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void _switCh(bool value)
    {
        ManagerOfMissle.isRemote = Toggle.isOn;
    }

    public void onSpeedChanged(string value)
    {
        ManagerOfMissle.speedOfMissle = float.Parse(speedI.text);
    }
    
    public void onAccelerationChanged(string value)
    {
        ManagerOfMissle.accelerationOfMissle = float.Parse(accelerationI.text);
    }
    
    public void onTimeChanged(string value)
    {
        ManagerOfMissle.timeOfPointing = float.Parse(timeI.text);
    }
    
    public void onAutroRangeChanged(string value)
    {
        ManagerOfMissle.automaticRange = float.Parse(radiusAI.text);
    }
    
    public void onOperatorRangeChanged(string value)
    {
        ManagerOfMissle.operatorRange = float.Parse(radiusOPI.text);
    }
    
    
    public void onRotationChanged(string value)
    {
        ManagerOfMissle.rotationOfMissle = float.Parse(rotationI.text);
    }
    
}
