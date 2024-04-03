using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1.5f, -5);
    public float followSpeed = 5;
    public float rotationSpeed = 5;
    private void FixedUpdate()
    {
        //Position
        //Emulating TransformPoint
        var rotatedOffset = target.rotation * offset;
        var offsetEmulatingTransformPoint = target.position + rotatedOffset;
        
        var offsetBasedOnTarget = target.TransformPoint(offset);
        transform.position = Vector3.Slerp(transform.position, offsetEmulatingTransformPoint, Time.deltaTime * followSpeed);
        
        //Rotation
        var desiredRotation = target.rotation
                       * Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}