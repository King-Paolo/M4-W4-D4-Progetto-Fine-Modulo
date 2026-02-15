using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _range;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform[] _shootPoint;
    [SerializeField] private AudioClip _sfx;

    private Transform _target;
    private float _lastTimeShoot;
    private AudioSource _audioSource;

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = _target.transform.position - transform.position;
            Vector3 turretDirection = direction;
            turretDirection.y = 0f;

            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction * _range, Color.red);

            Quaternion targetRotation = Quaternion.LookRotation(turretDirection);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            transform.rotation = rotation;

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _range))
            {
                if (hitInfo.transform.CompareTag("Player") && Time.time - _lastTimeShoot > _rateOfFire)
                {
                    Shoot();
                    _lastTimeShoot = Time.time;
                    Debug.Log("Lo vedo");
                }
            }
        }
    }

    public void Shoot()
    {
        foreach (Transform shootPoint in _shootPoint)
        {
            Vector3 direction = _target.transform.position - shootPoint.position;
            direction.Normalize();

            Bullet bullet = Instantiate(_bulletPrefab, shootPoint.position, Quaternion.LookRotation(direction));
            bullet.SetDirection(direction);

            if (_audioSource == null) _audioSource = GetComponent<AudioSource>();
            if (_audioSource != null)
            {
                _audioSource.clip = _sfx;
                _audioSource.Play();
            }
        }
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}
