using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class paramsOfFuel : MonoBehaviour
{
    public TMP_InputField fuel;
    public TMP_Text fuelPlace;
    
    public TMP_InputField fuelRoz;
    public TMP_Text fuelRozPlace;


    public Toggle toggleCool;

    public ManagerOfFuel ManagerOfFuel;
    
    // Start is called before the first frame update
    void Start()
    {
        fuelPlace.text = ManagerOfFuel.fuel.ToString();
        toggleCool.isOn = ManagerOfFuel.coolFuel;
        
        fuelRozPlace.text = ManagerOfFuel.fuelRoz.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void _switchB_(bool value)
    {
        ManagerOfFuel.coolFuel = toggleCool.isOn;
    }

    public void onFuelChanged(string value)
    {
        ManagerOfFuel.fuel = float.Parse(fuel.text);
    }
    
    public void onFuelRozChanged(string value)
    {
        ManagerOfFuel.fuelRoz = float.Parse(fuelRoz.text);
    }
}
