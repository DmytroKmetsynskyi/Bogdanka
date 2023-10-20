using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[CreateAssetMenu]
public class ManagerOfChil : ScriptableObject
{
    [Header("Chil")]
    public float speedOfChil = 10f;
    public float accelerationSpeedOfChil = 10f;
    public float rotationSpeedOfChil = 3.25f;
    public Vector3 sizeOfChil = new Vector3(1,1,1);
    public float massOfChil = 1f;
    public bool isLinearMoveOfChil = true;
}
