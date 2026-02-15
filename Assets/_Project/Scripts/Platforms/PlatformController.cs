using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private PlatformsType _type;
    [SerializeField] private float _speed;

    [Header("Info Moving Platform")]
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Transform _startPoint;

    [Header("Info Travel Platform")]
    [SerializeField] private Transform _endTravelPoint;

    [Header("Info Pushing Platform")]
    [SerializeField] private Transform _endPush;
    [SerializeField] private Transform _startPush;

    [Header("Info Elevator Platform")]
    [SerializeField] private Transform _startGamePoint;

    private Platforms _platform;
    private Rigidbody _rb;


    private void Awake()
    {
        if (_type == PlatformsType.Moving)
        {
            _platform = new MovingPlatform(_speed, _endPoint, _startPoint);
        }
        else if (_type == PlatformsType.Travel)
        {
            _platform = new TravelPlatform(_speed, _endTravelPoint);
        }
        else if (_type == PlatformsType.Falling)
        {
            _rb = GetComponent<Rigidbody>();
            _platform = new FallingPlatform(_rb);
        }
        else if (_type == PlatformsType.Elevator)
        {
            _platform = new ElevatorPlatform(_speed, _startGamePoint);
        }
        else if (_type == PlatformsType.Pushing)
        {
            _rb = GetComponent<Rigidbody>();
            _platform = new PushingPlatform(_speed, _endPush, _startPush, _rb);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_type == PlatformsType.Moving || _type == PlatformsType.Travel)
            {
                collision.transform.SetParent(transform);
            }

            if (_type == PlatformsType.Falling)
            {
                _platform.Activate();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_type == PlatformsType.Moving || _type == PlatformsType.Travel)
            {
                collision.transform.SetParent(null);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _platform.Activate();
        }
    }
    private void FixedUpdate()
    {
        _platform.Move(transform);
    }
}
