using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CanonRotatioj : MonoBehaviour
{
    public Transform chil;

    public float timeRemaining = 5;
    public GameObject prefabOfROcket;
    private byte numOfRockets = 0;
    public byte maxnumOfRockets = 1;

    public ManagerOfMissle ManagerOfMissle;


    private void Start()
    {
        timeRemaining = ManagerOfMissle.timeOfPointing;
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            transform.LookAt(chil);

        }
        else
        {
            if (numOfRockets < maxnumOfRockets)
            {
                Instantiate(prefabOfROcket, GameObject.Find("BulletPosition").transform.position, Quaternion.Euler(0, 90, 0));
                numOfRockets++;
            }
        }
    }
}
