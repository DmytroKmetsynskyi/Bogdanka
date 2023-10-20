using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class paramsOfPhy : MonoBehaviour
{
    public TMP_InputField in_;
    public TMP_Text inp;
    
    public ManagerOfPhy ManagerOfPhy;
    
    // Start is called before the first frame update
    void Start()
    {
        inp.text = ManagerOfPhy.g.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onPhyChanged(string value)
    {
        ManagerOfPhy.g = float.Parse(in_.text);

    }
}
