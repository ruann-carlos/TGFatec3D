using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TG.Movement;
using UnityEngine.InputSystem;
using System;

namespace TG.Core
{
    public class PlayerController : MonoBehaviour
    {
        InputSheet playerInput;
        Vector3 inputVector;
        
        private void Awake() {
            playerInput = new InputSheet();
        }

        private void OnEnable() {
            playerInput.Player.Enable();
            playerInput.Player.Move.performed += MovementPerformed;
        }


        private void OnDisable() {
            playerInput.Player.Disable();
            playerInput.Player.Move.performed -= MovementPerformed;
        }
        
        private void FixedUpdate() {
            
            inputVector = playerInput.Player.Move.ReadValue<Vector3>();
            GetComponent<Mover>().Move(inputVector);
        }

        private void MovementPerformed(InputAction.CallbackContext context)
        {
            GetComponent<Mover>().Move(inputVector);
        }

    }
}
