using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] float _groundDistance = 0.2f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _train;

    public bool isGrounded;
    public bool onBoard;

    private void FixedUpdate()
    {
        isGrounded = GroundChecker();
        onBoard = TrainChecker();
    }
    private bool GroundChecker()
    {
        return Physics.CheckSphere(transform.position, _groundDistance, _ground, QueryTriggerInteraction.Ignore);
    }

    private bool TrainChecker()
    {
        return Physics.CheckSphere(transform.position, _groundDistance, _train, QueryTriggerInteraction.Ignore);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _groundDistance);
    }
}
