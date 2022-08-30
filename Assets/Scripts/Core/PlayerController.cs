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
        Vector2 inputVector;
        bool runPressed;
        bool movementPressed;
        
        private void Awake() {
            playerInput = new InputSheet();
            playerInput.Player.Move.performed += VerifyRunning;
            playerInput.Player.Run.performed += context => runPressed = context.ReadValueAsButton();
            playerInput.Player.Move.canceled += context => {
                movementPressed = false;
                inputVector = Vector2.zero;
            };
        }

        private void OnEnable() {
            playerInput.Player.Enable();
            
        }

        private void OnDisable() {
            playerInput.Player.Disable();
        }
        
        private void FixedUpdate() {
            
        }

        private void VerifyRunning(InputAction.CallbackContext context){
            inputVector = playerInput.Player.Move.ReadValue<Vector2>();
            movementPressed = inputVector.x != 0 || inputVector.y != 0;
            MovementPerformed();
        }
        private void MovementPerformed()
        {
                GetComponent<Mover>().Move(movementPressed, runPressed);
                GetComponent<Mover>().RotateCharacter(inputVector);
        }

    }
}
