using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class CharacterAnimatorController : MonoBehaviour
    {
        public Animator animator;
        public CharacterMovement characterMovement;

        // Update is called once per frame
        void Update()
        {
            if(animator)
            {
               animator.SetBool("Walk", characterMovement.IsWalking());
            }    
        }
    }
}
