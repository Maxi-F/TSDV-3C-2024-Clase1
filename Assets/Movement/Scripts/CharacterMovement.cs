using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        [SerializeField] private float acceleration = 10;
        [SerializeField] private float rotationSpeed = 1;
        [SerializeField] private Rigidbody rigidBody;

        private Vector3 _desiredDirection = new Vector3(0, 0, 0);
        private Vector3 _vectorMovement;
        private float _angle;
        private bool isWalking;
        private Camera camera;

        private void Start()
        {
            isWalking = false;
        }

        private void OnValidate()
        {
            if(rigidBody == null)
            {
                rigidBody = GetComponent<Rigidbody>();
            }
        }

        private void Update()
        {
            getDirection();

            if (_desiredDirection == Vector3.zero && isWalking)
            {
                isWalking = false;
            }

            _angle = Vector3.SignedAngle(transform.forward, _desiredDirection, Vector3.up);
            transform.Rotate(0, _angle * (rotationSpeed * Time.deltaTime), 0);
        }

        private void FixedUpdate()
        {
            var currentVelocity = rigidBody.velocity;
            currentVelocity.y = 0;
            var currentSpeed = currentVelocity.magnitude;
            if(currentSpeed < speed) rigidBody.AddForce(_desiredDirection * acceleration, ForceMode.Force);
        }

        public void Move(Vector3 vectorMovement)
        {
            _vectorMovement = vectorMovement;

            if (!isWalking)
            {
                isWalking = true;
            }
        }
        public bool IsWalking()
        {
            return isWalking;
        }

        private void getDirection()
        {
            Transform localTransform = transform;

            if (camera != null)
                localTransform = camera.transform;
            else
                camera = Camera.main;

            _desiredDirection = localTransform.TransformDirection(_vectorMovement);
            _desiredDirection.y = 0;
        }
    }
}
