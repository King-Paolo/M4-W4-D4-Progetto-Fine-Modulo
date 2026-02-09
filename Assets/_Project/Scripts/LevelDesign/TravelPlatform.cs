using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TravelPlatform : Platforms
{
    private float _speed;
    private Transform _endTravelPoint;

    private bool _enabled = false;

    public TravelPlatform(float speed, Transform endTravelPoint)
    {
        _speed = speed;
        _endTravelPoint = endTravelPoint;
    }

    public override void Activate()
    {
        _enabled = true;
    }
    public override void Move(Transform platformPosition)
    {
        int direction = -1;
        if (_enabled)
        {
            platformPosition.Translate(Vector3.forward * _speed * direction * Time.deltaTime);
        }

        if (platformPosition.position.z <= _endTravelPoint.transform.position.z)
        {
            _enabled = false;
        }
    }
}
