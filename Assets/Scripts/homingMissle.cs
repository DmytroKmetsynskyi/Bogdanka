using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class homingMissle : MonoBehaviour
{
    [Header("REFERENCES")] 
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Chil _target;
        
    [Header("MOVEMENT")] 
    [SerializeField] private float _speed = 15;
    [SerializeField] private float _rotateSpeed = 95;
        
    [Header("ACCELERATION")]
    [SerializeField] private float _accelerationSpeed = 25;

    [Header("PREDICTION")] 
    [SerializeField] private float _maxDistancePredict = 100;
    [SerializeField] private float _minDistancePredict = 5;
    [SerializeField] private float _maxTimePrediction = 5;
    private Vector3 _standardPrediction, _deviatedPrediction;

    [Header("DEVIATION")] 
    [SerializeField] private float _deviationAmount = 50;
    [SerializeField] private float _deviationSpeed = 2;

    [Header("PARTICLE")] public GameObject particle;
        
    [Header("FUEL")]
    public float sfuell = 1000.0f;
    public float fuell = 1000.0f;
    public float _fuell = 50.0f;

    public bool acceleration = true;
    public bool _havayuPalne = true;
    public bool nedoacceleration = false;

    public ManagerOfFuel ManagerOfFuel;
    
    public bool endlessFuel = false;

    public ManagerOfMissle ManagerOfMissle;


        
        private void Start()
        {
            sfuell = ManagerOfFuel.fuel;
            fuell = ManagerOfFuel.fuel;
            _fuell = ManagerOfFuel.fuelRoz;
            
            endlessFuel = ManagerOfFuel.coolFuel;
            
            _speed = ManagerOfMissle.speedOfMissle;
            _accelerationSpeed = ManagerOfMissle.accelerationOfMissle;
            _rotateSpeed = ManagerOfMissle.rotationOfMissle;
            
            _target = GameObject.Find("Chil").GetComponent<Chil>();

            CinemachineVirtualCamera cinemachineVirtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();

            cinemachineVirtualCamera.Follow = gameObject.GetComponent<Transform>();
            cinemachineVirtualCamera.LookAt = gameObject.GetComponent<Transform>();
            
            StartCoroutine(havayuPalne());

            _rb.mass += fuell / 100.0f;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name == "Chil")
            {
                Destroy(other.gameObject);
                DestroyMissle();
            }

            if (other.gameObject.tag == "Obstacle" && !acceleration && !_havayuPalne)
            {
                DestroyMissle();
            }
        }

        private void FixedUpdate()
        {
            if (acceleration)
            {
                _rb.velocity = transform.forward * _speed;
                
                var leadTimePercentage = Mathf.InverseLerp(_minDistancePredict, _maxDistancePredict, Vector3.Distance(transform.position, _target.transform.position));

                
                PredictMovement(leadTimePercentage);

                AddDeviation(leadTimePercentage);

                RotateRocket();
            }

            if (acceleration)
            {
                _speed += _accelerationSpeed * Time.fixedDeltaTime;
            }

            if (nedoacceleration)
            {
                _speed -= _accelerationSpeed * Time.fixedDeltaTime;
            }

            

            if (fuell <= 0f)
            {
                acceleration = false;
                _havayuPalne = false;

                nedoacceleration = true;
            }

            if (_speed <= 0f)
            {
                nedoacceleration = false;
            }
        }
        
        IEnumerator havayuPalne()
        {
            while (_havayuPalne && !endlessFuel)
            {
                yield return new WaitForSeconds(1);
                fuell -= _fuell;
            }
        }

        private void PredictMovement(float leadTimePercentage) {
            var predictionTime = Mathf.Lerp(0, _maxTimePrediction, leadTimePercentage);

            _standardPrediction = _target.Rb.position + _target.Rb.velocity * predictionTime;
        }

        private void AddDeviation(float leadTimePercentage) {
            var deviation = new Vector3(Mathf.Cos(Time.time * _deviationSpeed), 0, 0);
            
            var predictionOffset = transform.TransformDirection(deviation) * _deviationAmount * leadTimePercentage;

            _deviatedPrediction = _standardPrediction + predictionOffset;
        }

        private void RotateRocket()
        {
            var heading = _deviatedPrediction - transform.position;

            var rotation = Quaternion.LookRotation(heading);
            _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
        }

        public void DestroyMissle()
        {
            Destroy(gameObject);
            Instantiate(particle, transform.position, Quaternion.Euler(-90,0,0));
        }
}
