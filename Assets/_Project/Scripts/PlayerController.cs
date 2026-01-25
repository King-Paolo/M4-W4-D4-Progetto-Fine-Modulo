using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _rotationSpeed = 5;

    private Rigidbody _rb;
    private float _horizontal;
    private float _vertical;
    Camera _mainCamera;
    Vector3 _currentDirection;
    GroundCheck _gc;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        _gc = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _currentDirection = _mainCamera.transform.forward * _vertical + _mainCamera.transform.right * _horizontal;
        _currentDirection.y = 0;

        if(_currentDirection.magnitude > 0.01f)
            _currentDirection.Normalize();

        if(Input.GetButtonDown("Jump") && _gc.isGrounded)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        if (_currentDirection.magnitude > 0.01f)
        {
            Vector3 velocity = _currentDirection * _speed;
            _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);

            Quaternion targetRotation = Quaternion.LookRotation(_currentDirection);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rb.MoveRotation(rotation);
        }
        else
        { 
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }       
    }
       public void Jump()
    {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);      
    }
}
