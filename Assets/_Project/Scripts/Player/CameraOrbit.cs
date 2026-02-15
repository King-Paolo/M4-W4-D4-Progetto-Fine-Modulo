using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] float _mouseSensitivity = 3f;
    [SerializeField] float _bottomClamp = -30f;
    [SerializeField] float _topClamp = 60f;
    [SerializeField] Vector3 _offset = new Vector3(0, 2, -7);

    Transform _target;
    float yaw;
    float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * _mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * _mouseSensitivity;
        pitch = Mathf.Clamp(pitch, _bottomClamp, _topClamp);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        if (_target != null)
        {
            Vector3 cameraPosition = _target.position + rotation * _offset;

            Vector3 lookAt = _target.position + Vector3.up * 2;
            Quaternion lookRotation = Quaternion.LookRotation(lookAt - cameraPosition);
            transform.SetPositionAndRotation(cameraPosition, lookRotation);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}
