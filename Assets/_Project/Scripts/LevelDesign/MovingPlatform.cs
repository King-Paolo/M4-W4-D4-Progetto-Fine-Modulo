using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platforms
{
    private float _speed;
    private Transform _endPoint;
    private Transform _startPoint;
    private int direction = 1;

    public MovingPlatform(float speed, Transform endPoint, Transform startPoint)
    {
        _speed = speed;
        _endPoint = endPoint;
        _startPoint = startPoint;
    }

    public override void Move(Transform platformPosition)
    {
        platformPosition.Translate(Vector3.forward * _speed * direction * Time.deltaTime);

        if (platformPosition.position.z <= _startPoint.transform.position.z)
        {
            direction = 1;
        }

        if (platformPosition.position.z >= _endPoint.transform.position.z)
        {
            direction = -1;
        }
    }
}
