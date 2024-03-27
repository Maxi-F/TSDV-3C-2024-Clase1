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
        private bool isWalking;

        private void Start()
        {
            isWalking = false;
        }


        public void Move(Vector3 vectorMovement)
        {
            _desiredDirection = vectorMovement;

            if(!isWalking)
            {
                isWalking = true;
            }
        }

        private void Update()
        {
            if(_desiredDirection == Vector3.zero && isWalking)
            {
                isWalking = false;
            }

            transform.position += (_desiredDirection * (speed * Time.deltaTime));
            _angle = Vector3.SignedAngle(transform.forward, _desiredDirection, Vector3.up);

            transform.Rotate(0, _angle * (speed * Time.deltaTime), 0);
        }

        public bool IsWalking()
        {
            return isWalking;
        }
    }
}
