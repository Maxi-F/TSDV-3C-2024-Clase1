using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, -1.5f, 5);
    public float rotationSpeed = 5;
    public float followSpeed = 5;

    void LateUpdate()
    {
        // Position
        var offsetBasedOnTarget = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, offsetBasedOnTarget, followSpeed * Time.deltaTime);

        // Rotation
        var rotation = target.rotation * Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
