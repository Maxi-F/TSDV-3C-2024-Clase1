using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string speedParameter = "speed";
    [SerializeField] private Rigidbody rigidBody;

    private void Update()
    {
        if (animator && rigidBody)
        {
            var horVelocity = rigidBody.velocity;
            horVelocity.y = 0;
            var speed = horVelocity.magnitude;
            animator.SetFloat(speedParameter, speed);
        }
    }
}
