using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class InputReader : MonoBehaviour
    {
        public CharacterMovement characterMovement;

        private void Awake()
        {
            if (characterMovement == null)
            {
                Debug.LogError($"{name}: {nameof(characterMovement)} is null!" +
                               $"\nThis class is dependant on a CharacterMovement component!");
            }
        }

        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
            if (characterMovement != null)
                characterMovement.Move(moveDirection);
        }
    }
}
