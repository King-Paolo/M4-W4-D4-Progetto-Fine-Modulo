using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Victory : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private UnityEvent _onVictory;
    [SerializeField] private GameObject _prize;
    [SerializeField] private AudioClip _sfx;

    private bool _prizeSpawned;
    private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            _timer.VictoryTimer();

            if (player.Score == 100 && !_prizeSpawned)
            {
                if (_audioSource == null)
                {
                    _audioSource = GetComponent<AudioSource>();
                }

                if (_audioSource != null)
                {
                    _audioSource.clip = _sfx;
                    _audioSource.Play();
                }

                _prize.SetActive(true);
                _prizeSpawned = true;
                return;
            }
            _onVictory.Invoke();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
