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
    private TrainPlatform[] _trains;
    private int _score;
    private float _timer;
    private float _timeBonus;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        _gc = GetComponentInChildren<GroundCheck>();
        _trains = FindObjectsOfType<TrainPlatform>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _currentDirection = _mainCamera.transform.forward * _vertical + _mainCamera.transform.right * _horizontal;
        _currentDirection.y = 0;

        if (_currentDirection.magnitude > 0.01f)
            _currentDirection.Normalize();

        if (Input.GetButtonDown("Jump") && (_gc.isGrounded || _gc.onBoard))
        {
            Jump();
            if (transform.parent != null && _gc.onBoard)
            {
                foreach (TrainPlatform train in _trains)
                {
                    train.StopTrain();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponentInParent<TrainPlatform>() != null)
        {
            foreach (TrainPlatform train in _trains)
            {
                train.StartTrain();
            }
        }
        else if (collision.collider.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect(this);
            Debug.Log("Punteggio" + _score);
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;

        if (_currentDirection.magnitude > 0.01f)
        {
            velocity = _currentDirection * _speed;

            Quaternion targetRotation = Quaternion.LookRotation(_currentDirection);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rb.MoveRotation(rotation);
        }

        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
    }
    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void AddScore(int amount)
    {
        _score += amount;
    }

    public void AddTime(float seconds)
    {
        _timeBonus += seconds;
    }
}

