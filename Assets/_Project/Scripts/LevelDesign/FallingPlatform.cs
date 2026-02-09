using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : Platforms
{
    private Rigidbody _rb;
    private float _timeOnPlatform;
    private bool _isCounting;
    public FallingPlatform(Rigidbody rb)
    {
        _rb = rb;
        _rb.isKinematic = true;
    }

    public override void Activate()
    {
        _timeOnPlatform = Time.time;
        _isCounting = true;
    }

    public override void Move(Transform platformPosition)
    {
        if (_isCounting == false)
            return;
        else
        if (Time.time - _timeOnPlatform >= 0.5f)
        {
            _rb.isKinematic = false;
            _isCounting = false;
        }
    }

}
