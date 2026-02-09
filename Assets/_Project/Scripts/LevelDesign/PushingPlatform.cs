using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingPlatform : Platforms
{
    private float _speed;
    private Transform _endPush;
    private Transform _startPush;
    private int direction = 1;
    private Rigidbody _rb;

    public PushingPlatform(float speed, Transform endPush, Transform startPush, Rigidbody rb)
    {
        _speed = speed;
        _endPush = endPush;
        _startPush = startPush;
        _rb = rb;
        _rb.isKinematic = true;
    }

    public override void Move(Transform platformPosition)
    {
        float pushSpeed = _speed;

        if (direction == 1)
        {
            pushSpeed *= 2;
        }
        else
        {
            pushSpeed *= 0.25f;
        }

        _rb.MovePosition(_rb.position + Vector3.forward * (pushSpeed * direction * Time.deltaTime));

        if (platformPosition.position.z <= _startPush.transform.position.z)
        {
            direction = 1;
        }

        else if (platformPosition.position.z >= _endPush.transform.position.z)
        {
            direction = -1;
        }
    }
}
