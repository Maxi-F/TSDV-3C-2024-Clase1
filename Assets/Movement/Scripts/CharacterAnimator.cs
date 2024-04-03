using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator animator;
    public CharacterMovement movement;
    private void Update()
    {
        if (animator && movement)
        {
            animator.SetFloat("speed", movement.CurrentSpeed);
        }
    }
}
