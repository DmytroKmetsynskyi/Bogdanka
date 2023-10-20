using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ManagerOfMissle : ScriptableObject
{
    public float timeOfPointing = 5f;
    public float speedOfMissle = 10f;
    public float accelerationOfMissle = 8f;
    public float rotationOfMissle = 150f;
    public bool isRemote = true;
    public float automaticRange = 10f;
    public float operatorRange = 100f;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
