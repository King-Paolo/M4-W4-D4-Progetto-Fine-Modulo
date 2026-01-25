using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platforms
{
    private float speed;
    private Transform endPoint;
    public MovingPlatform(float speed, Transform endPoint)
    {
        this.speed = speed;
        this.endPoint = endPoint;
    }

    public override void Move(Transform platformPosition)
    {
        platformPosition.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
