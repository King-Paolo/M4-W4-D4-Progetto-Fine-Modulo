using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : MonoBehaviour, ICollectable
{
    [SerializeField] private float _rotationSpeed = 5;
    private int _coinValue = 5;
    public void Collect(PlayerController player)
    {
        player.AddScore(_coinValue);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.right, _rotationSpeed * Time.fixedDeltaTime);
    }
}
