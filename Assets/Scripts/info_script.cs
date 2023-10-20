using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class info_script : MonoBehaviour
{
    public Text coordinatesChil;
    public Text coordinatesMissle;
    
    public Text FPS;

    public float fps = 0;
    public float _fps = 0;

    public Transform Chil;
    public Transform Missle;

    public RocketController RocketController;
    
    void Update()
    {
        if (RocketController.remoteRocket)
        {
            Missle = GameObject.Find("RocketRemote(Clone)").GetComponent<Transform>();
        }
        else
        {
            Missle = GameObject.Find("Rocket(Clone)").GetComponent<Transform>();
        }


        coordinatesMissle.text = "Координати снаряда: x " + Mathf.Round(Missle.position.x) + " y " + Mathf.Round(Missle.position.y) + " z " +
                                 Mathf.Round(Missle.position.z);
        
        coordinatesChil.text = "Координати цілі: x " + Mathf.Round(Chil.position.x) + " y " + Mathf.Round(Chil.position.y) + " z " +
                                 Mathf.Round(Chil.position.z);

        fps = (1.0f / Time.fixedDeltaTime);
        _fps = (1.0f / Time.deltaTime);
        
        FPS.text = "FPS: " + fps;
    }
}
