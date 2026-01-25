using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] float _groundDistance = 0.2f;
    [SerializeField] LayerMask ground;

    public bool isGrounded;

    private void FixedUpdate()
    {
        isGrounded = GroundChecker();
    }
    private bool GroundChecker()
    {
        return Physics.CheckSphere(transform.position, _groundDistance, ground, QueryTriggerInteraction.Ignore);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _groundDistance);
    }
}
