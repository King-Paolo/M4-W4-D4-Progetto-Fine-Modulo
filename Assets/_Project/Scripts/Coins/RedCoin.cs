using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : MonoBehaviour, ICollectable
{
    [SerializeField] private float _rotationSpeed = 5;
    [SerializeField] private AudioClip _sfx;

    private int _coinValue = 5;
    private AudioSource _audioSource;

    public void Collect(PlayerController player)
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

        player.AddScore(_coinValue);
        Destroy(gameObject, _audioSource.clip.length);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.right, _rotationSpeed * Time.fixedDeltaTime);
    }
}
