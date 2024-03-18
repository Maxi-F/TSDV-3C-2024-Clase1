using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class InputReader : MonoBehaviour
    {
        public CharacterMovement characterMovement;

        private void Awake()
        {
            if(characterMovement == null)
            {
                Debug.LogError($"{name}: {nameof(characterMovement)} is null! \n this class is dependant on a {nameof(characterMovement)} component.");
            }
        }
        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            if (characterMovement != null)
                characterMovement.Move(new Vector3(moveInput.x, 0, moveInput.y));
        }
    }
}
