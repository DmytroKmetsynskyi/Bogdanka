using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setterOfPhy : MonoBehaviour
{

    public ManagerOfPhy ManagerOfPhy;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -ManagerOfPhy.g, 0);
        
        Debug.Log(Physics.gravity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
