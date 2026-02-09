using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private Rigidbody _rb;
    private Vector3 _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

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
                Debug.Log("Colpito");
            }
        }
        else
        {
            transform.position += move;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //LifeController player = collision.gameObject.GetComponent<LifeController>();

        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    player.TakeDamage(_damage);
        //    Destroy(gameObject);
        //    Debug.Log("colpito");
        //}
        //else
            Destroy(gameObject);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
        //_rb.velocity = direction * _speed;
    }
}
