using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _gameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            _gameOver.Invoke();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
