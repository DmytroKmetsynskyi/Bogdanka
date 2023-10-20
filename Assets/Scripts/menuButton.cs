using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuButton : MonoBehaviour
{

    public bool isOn = false;
    public Sprite menuSprite;
    public Sprite crossSprite;
    public GameObject canvasPlay;
    public GameObject canvasConf;
    public GameObject canvasMenu;
    public Image imageOfButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            imageOfButton.sprite = crossSprite;
            canvasPlay.SetActive(false);
            canvasMenu.SetActive(true);
            canvasConf.SetActive(true);
            
        }
        else
        {
            imageOfButton.sprite = menuSprite;
            canvasPlay.SetActive(true);
            canvasMenu.SetActive(false);
            canvasConf.SetActive(false);

        }
    }

    public void switch_()
    {
        isOn = !isOn;
    }
}
