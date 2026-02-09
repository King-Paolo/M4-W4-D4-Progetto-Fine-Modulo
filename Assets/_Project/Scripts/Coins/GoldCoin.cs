using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour, ICollectable
{
    [SerializeField] private float _rotationSpeed = 250;
    private int _coinValue = 1;
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
