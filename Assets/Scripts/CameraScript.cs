using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera _camera;
    public float lvl = 10.0f;

    public Image imageOfButton;
    public Sprite playSprite;
    public Sprite pauseSprite;
    

    public bool pause = false;
    
    void Start()
    {
        pause = false;
        Time.timeScale = 1f;
    }


    public void speedUpButton()
    {
        Time.timeScale = 2.0f;
    }
    
    public void speedDownButton()
    {
        Time.timeScale = 0.5f;
    }
    
    public void pauseButton()
    {
        if (pause)
        {
            Time.timeScale = 1f;
            pause = false;
            imageOfButton.sprite = pauseSprite;
        } else if (!pause)
        {
            Time.timeScale = 0f;
            pause = true;
            imageOfButton.sprite = playSprite;
        }
    }

    public void zoomUp()
    {
        _camera.m_Lens.FieldOfView -= lvl;
    }

    public void zoomIn()
    {
        _camera.m_Lens.FieldOfView += lvl;
    }
}
