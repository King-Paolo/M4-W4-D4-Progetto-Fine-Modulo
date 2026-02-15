using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorPlatform : Platforms
{
    private float _speed;
    private Transform _stopPoint;
    private bool _enabled = false;

    public ElevatorPlatform(float speed, Transform startGamePoint)
    {
        _speed = speed;
        _stopPoint = startGamePoint;
    }

    public override void Activate()
    {
        _enabled = true;
    }

    public override void Move(Transform platformTransform)
    {
        if (_enabled)
        {
            platformTransform.Translate(Vector3.up * _speed * Time.deltaTime);
        }

        if (platformTransform.position.y >= _stopPoint.transform.position.y)
        {
            _enabled = false;
        }
    }
}
