using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParamsOfChild : MonoBehaviour
{
    public TMP_InputField speedInput;
    public TMP_InputField accelerationInput;
    public TMP_InputField rotationInput;
    public TMP_InputField massInput;
    public Toggle isLinearMoveToggle;

    public TMP_Text speedText;
    public TMP_Text accelerationText;
    public TMP_Text rotationText;
    public TMP_Text massText;

    public ManagerOfChil gameManager;

    private void Start()
    {
        speedText.text = gameManager.speedOfChil.ToString();
        accelerationText.text = gameManager.accelerationSpeedOfChil.ToString();
        rotationText.text = gameManager.rotationSpeedOfChil.ToString();
        massText.text = gameManager.massOfChil.ToString();

        isLinearMoveToggle.isOn = gameManager.isLinearMoveOfChil;
    }

    private void Update()
    {
    }


    public void _switchB_(bool value)
    {
        gameManager.isLinearMoveOfChil = isLinearMoveToggle.isOn;
    }
    
    
    public void onSpeedChanged(string value)
    {
        gameManager.speedOfChil = float.Parse(speedInput.text);
    }
    
    public void onAccelertationChanged(string value)
    {
        gameManager.accelerationSpeedOfChil = float.Parse(accelerationInput.text);
    }
    
    public void onRotationChanged(string value)
    {
        gameManager.rotationSpeedOfChil = float.Parse(rotationInput.text);
    }
    
    public void onMassChanged(string value)
    {
        gameManager.massOfChil = float.Parse(massInput.text);
    }
}