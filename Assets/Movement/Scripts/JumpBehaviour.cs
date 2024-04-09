using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float force = 15f;
    private bool _iWantToJump;
    [SerializeField] private float groundedDistance = .01f;
    [SerializeField] private LayerMask floor;
    [SerializeField] private Transform feetPivot;
    private Ray _groundRay;

    private void Reset()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        //These are both the same
        // if (!_rigidbody)
        // {
        //     _rigidbody = GetComponent<Rigidbody>();
        // }

        _rigidbody ??= GetComponent<Rigidbody>();
    }
    
    public void Jump()
    {
        Debug.Log($"{name}: Jumped!");
        _iWantToJump = true;
    }

    private void FixedUpdate()
    {
        if (_iWantToJump && CanJump())
        {
            _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            _iWantToJump = false;
        }
    }

    private bool CanJump()
    {
        if (!feetPivot)
        {
            Debug.LogWarning($"{name}: {nameof(feetPivot)} is null!");
            return false;
        }
        //I must be at ground level
        if (Physics.Raycast(feetPivot.position, Vector3.down, out var hit, groundedDistance, floor))
        {
            Vector3.Angle(Vector3.up, hit.normal)
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(feetPivot.position, Vector3.down * groundedDistance);
    }
}