using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class docScript : MonoBehaviour
{
    public bool isOn = false;
    public GameObject canvasDoc;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            canvasDoc.SetActive(true);
        }
        else
        {
            canvasDoc.SetActive(false);
        }
    }

    public void switch_()
    {
        isOn = !isOn;
    }

    public void quit()
    {
        Application.Quit();
    }
}
