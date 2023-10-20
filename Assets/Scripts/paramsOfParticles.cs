using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class paramsOfParticles : MonoBehaviour
{
    public TMP_InputField speedIn;
    public TMP_Text speedPl;
    
    public TMP_InputField radiusIn;
    public TMP_Text radiusPlace;

    public ManagerOfParticles ManagerOfParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        radiusPlace.text = ManagerOfParticles.radiusOfParticles.ToString();
        speedPl.text = ManagerOfParticles.speedOfParticles.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void onSpeedChanged(string value)
    {
        ManagerOfParticles.speedOfParticles = float.Parse(speedIn.text);
    }
    
    public void onRadiusChanged(string value)
    {
        ManagerOfParticles.radiusOfParticles = float.Parse(radiusIn.text);
    }
}
