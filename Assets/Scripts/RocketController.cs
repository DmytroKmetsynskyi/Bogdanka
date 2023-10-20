using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public bool remoteRocket = false;
    public CanonRotatioj CanonRotatioj;
    public ManagerOfMissle ManagerOfMissle;

    private void Start()
    {
        remoteRocket = ManagerOfMissle.isRemote;
    }

    private void FixedUpdate()
    {
        if (!remoteRocket)
        {
            CanonRotatioj.prefabOfROcket = Resources.Load<GameObject>("Prefabs/Rocket");
        }
        else
        {
            CanonRotatioj.prefabOfROcket = Resources.Load<GameObject>("Prefabs/RocketRemote");

        }
    }
}
