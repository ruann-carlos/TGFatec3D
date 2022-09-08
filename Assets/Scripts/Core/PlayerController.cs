using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TG.Movement;
using UnityEngine.InputSystem;
using System;
using TG.Combat;

namespace TG.Core
{
    public class PlayerController : MonoBehaviour
    {
        InputSheet playerInput;
        Vector2 inputVector;
        Vector3 characterDirection;
        Mover playerMover;
        Animator animator;
        bool runPressed;
        bool movementPressed;
        
        private void Awake() {
            playerInput = new InputSheet();
            playerMover = GetComponent<Mover>();
            animator  = GetComponent<Animator>();
            playerInput.Player.Move.started += OnMovementPerformed;
            playerInput.Player.Move.performed += OnMovementPerformed;
            playerInput.Player.Move.canceled += OnMovementPerformed;
            playerInput.Player.Run.performed += OnRunPerformed;
            playerInput.Player.Fire.performed += OnAttackPerformed;
            playerInput.Player.Defend.started += OnBlockPressed;
            playerInput.Player.Defend.canceled += OnBlockReleased;
        }

        private void OnEnable() {
            playerInput.Player.Enable();
        }

        private void OnDisable() {
            playerInput.Player.Disable();
        }
        
        private void FixedUpdate() {
            MovementPerformed();
            HandleAnimation();
        }

        private void OnMovementPerformed(InputAction.CallbackContext context){
            inputVector = playerInput.Player.Move.ReadValue<Vector2>();
            characterDirection.x = inputVector.x;
            characterDirection.y = 0;
            characterDirection.z = inputVector.y;
            movementPressed = inputVector.x != 0 || inputVector.y != 0;
        }

        private void OnRunPerformed(InputAction.CallbackContext context){
            runPressed = context.ReadValueAsButton();
        }
        
        private void OnAttackPerformed(InputAction.CallbackContext context){
                GetComponent<Fighter>().SetAttackAnimation();
        }

        private void MovementPerformed()
        {
            playerMover.MoveCharacterRelativeToCamera(characterDirection, runPressed);
            playerMover.RotateCharacter(characterDirection, movementPressed);
        }

        private void OnBlockPressed(InputAction.CallbackContext context){
            GetComponent<Fighter>().SetDefenseAnimation(true);
        }

        private void OnBlockReleased(InputAction.CallbackContext context){
            GetComponent<Fighter>().SetDefenseAnimation(false);
        }

        public void HandleAnimation(){
            bool isRunning = animator.GetBool("running");
            bool isWalking = animator.GetBool("walking");
            
            if(movementPressed && !isWalking){
                animator.SetBool("walking", true);
            }else if (!movementPressed && isWalking){
                animator.SetBool("walking", false);
            }
            if((movementPressed && runPressed) && !isRunning){
                animator.SetBool("running", true);
            }else if(((movementPressed && !runPressed) || (!movementPressed && runPressed)) && isRunning ){
                animator.SetBool("running", false);
            }
        }

    }
}
