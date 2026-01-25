using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _endPoint;
    private Platforms _platform;


    private void Awake()
    {
        _platform = new MovingPlatform(_speed, _endPoint);
    }

    private void Update()
    {
        _platform.Move(transform);
    }
}
