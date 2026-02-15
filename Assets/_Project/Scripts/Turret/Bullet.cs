using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    private void FixedUpdate()
    {
        Vector3 move = _direction * _speed * Time.deltaTime;
        if (Physics.Raycast(transform.position, _direction, out RaycastHit hit, move.magnitude))
        {
            LifeController player = hit.collider.GetComponent<LifeController>();
            if (player != null)
            {
                player.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position += move;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
