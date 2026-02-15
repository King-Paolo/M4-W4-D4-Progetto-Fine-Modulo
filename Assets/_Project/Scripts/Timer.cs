using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _onStartCountdown;
    [SerializeField] private UnityEvent _onEndCountdown;
    [SerializeField] private float _totalTime = 180;

    private bool _gameStarted;
    private float _startTime;
    private bool _isFinished;
    private float _timeRemaning;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_gameStarted)
        {
            _gameStarted = true;
            _startTime = Time.time;
        }
    }

    private void Update()
    {
        if (!_gameStarted || _isFinished)
            return;

        if (_gameStarted)
        {
            _timeRemaning = Mathf.Max(0, _totalTime - (Time.time - _startTime));
            _onStartCountdown.Invoke(_timeRemaning);

            if (_timeRemaning <= 0)
            {
                Time.timeScale = 0;
                _onEndCountdown.Invoke();
                _isFinished = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void VictoryTimer()
    {
        if (_gameStarted && !_isFinished)
        {
            _timeRemaning = Time.time - _startTime;
            _isFinished = true;
        }
    }

    public void AddTime(float seconds)
    {
        _totalTime += seconds;
    }
}
