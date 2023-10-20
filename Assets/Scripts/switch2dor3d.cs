using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class switch2dor3d : MonoBehaviour
{
    public GameObject CinemachineVirtualCamera;
    public GameObject missle;

    public bool is2d = false;
    public Image modeText;

    public Sprite super2dSprite;
    public Sprite super3dSprite;
    
    public RocketController RocketController;

    public void switch_() 
    {
        if (!is2d)
        {
            is2d = true;
            modeText.sprite = super3dSprite;
        } else if (is2d)
        {
            is2d = false;
            modeText.sprite = super2dSprite;
        }
    }

    private void FixedUpdate()
    {
        CinemachineVirtualCamera _cinemachineVirtualCamera = CinemachineVirtualCamera.GetComponent<CinemachineVirtualCamera>();
        
        if (is2d)
        {
            Camera.main.orthographic = true;
            CinemachineVirtualCamera.transform.position = new Vector3(60, 26, -200);
            CinemachineVirtualCamera.transform.rotation = Quaternion.Euler(0,0,0);
            _cinemachineVirtualCamera.LookAt = null;
            _cinemachineVirtualCamera.Follow = null;

            _cinemachineVirtualCamera.m_Lens.OrthographicSize = 80;
        } else if (!is2d)
        {
            if (RocketController.remoteRocket)
            {
                missle = GameObject.Find("RocketRemote(Clone)");
            }
            else
            {
                missle = GameObject.Find("Rocket(Clone)");
            }
            
            Camera.main.orthographic = false;

            Transform missleTransform = missle.transform;

            _cinemachineVirtualCamera.LookAt = missleTransform;
            _cinemachineVirtualCamera.Follow = missleTransform;
        }
    }
}
