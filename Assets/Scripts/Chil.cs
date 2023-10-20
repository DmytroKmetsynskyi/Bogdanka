using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Chil : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _accelerationSpeed = 25;
    public float rotationSpeed = 3.25f;
    public bool forwardMove;
    public Vector3 scale;
    public Vector3[] coordinates;
    private int currentIndex = 0;
    
    public GameObject particle;

    public RocketController RocketController;

    public GameObject loseText;
    
    public Rigidbody Rb => _rb;

    public bool acceleration = true;

    public BoxCollider BoxCollider;


    public ManagerOfChil chilManager;

    public GameObject modelOfShahed;
    public GameObject modelOfRocket;
    
    

    private void Start()
    {
        _speed = chilManager.speedOfChil;
        _accelerationSpeed = chilManager.accelerationSpeedOfChil;
        rotationSpeed = chilManager.rotationSpeedOfChil;
        _rb.mass = chilManager.massOfChil;
        forwardMove = chilManager.isLinearMoveOfChil;

        BoxCollider = GetComponent<BoxCollider>();
        
        
        if (!forwardMove)
        {
            StartCoroutine(MoveToNextPoint());
        }
        else
        {
            BoxCollider.center = new Vector3(0, 0, 0);
            BoxCollider.size = new Vector3(3.3f, 3, 30);
            modelOfShahed.SetActive(false);
            modelOfRocket.SetActive(true);
        }
        
        transform.localScale = scale;

        if (acceleration)
        {
            _speed += _accelerationSpeed;
        }
        


    }

    IEnumerator MoveToNextPoint()
    {
        while (currentIndex < coordinates.Length)
        {
            Vector3 targetPosition = coordinates[currentIndex];
            float distance = Vector3.Distance(transform.position, targetPosition);
            
            while (distance > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
                distance = Vector3.Distance(transform.position, targetPosition);
                yield return null;
            }

            currentIndex++;
            
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if (forwardMove)
        {
            _rb.velocity = Vector3.right * _speed;
        }
        
        if (currentIndex < coordinates.Length)
        {
            Vector3 direction = (coordinates[currentIndex] - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            loseText.SetActive(true);
            
            Destroy(gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);

            if (RocketController.remoteRocket)
                GameObject.Find("RocketRemote(Clone)").GetComponent<homingMissle_remote>().DestroyMissle();
            else 
                GameObject.Find("Rocket(Clone)").GetComponent<homingMissle>().DestroyMissle();
        }
    }
    
    public void DestroyChil()
    {
        Destroy(gameObject);
        Instantiate(particle, transform.position, Quaternion.Euler(-90,0,0));
    }

}
