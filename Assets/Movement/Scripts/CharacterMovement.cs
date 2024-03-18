using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        public float speed = 1;

        private Vector3 _desiredDirection = new Vector3(0, 0, 0);
        private float _angle;

        public void Move(Vector3 vectorMovement)
        {
            _desiredDirection = vectorMovement;
        }

        private void Update()
        {
            transform.position += (_desiredDirection * (speed * Time.deltaTime));
            _angle = Vector3.SignedAngle(transform.forward, _desiredDirection, Vector3.up);
            
            Debug.Log($"rotation: {transform.rotation.y}");
            transform.Rotate(0, _angle * (speed * Time.deltaTime), 0);
            Debug.Log($"angle: {_angle}");
            Debug.Log($"rotation after: {transform.rotation.y}");
        }
    }
}
