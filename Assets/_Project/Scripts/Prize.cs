using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Prize : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;
    [SerializeField] private UnityEvent _onVictory;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _onVictory.Invoke();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.right, _rotationSpeed * Time.fixedDeltaTime);
    }
}
