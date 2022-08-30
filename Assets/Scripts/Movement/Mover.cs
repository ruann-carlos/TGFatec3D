using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5;
        Rigidbody rigidBody;
        Animator animator;
        int isWalkingHash;
        int isRunningHash;

        private void Start() {
            rigidBody = GetComponent<Rigidbody>();
            animator  = GetComponent<Animator>();
            isWalkingHash = Animator.StringToHash("walking");
            isRunningHash = Animator.StringToHash("running");
        }

        public void Move(bool movementPressed, bool RunPressed){
            
            bool _isRunning = animator.GetBool(isRunningHash);
            bool _isWalking = animator.GetBool(isWalkingHash);

            if(movementPressed && !_isWalking){
                animator.SetBool(isWalkingHash, true);                
            }

            if(!movementPressed && _isWalking){
                animator.SetBool(isWalkingHash,false);
            }

            if((movementPressed && RunPressed) && !_isRunning){
                animator.SetBool(isRunningHash, true);
            }

            if((!movementPressed || !RunPressed) && _isRunning){
                animator.SetBool(isRunningHash, false);
            }

        }

        public void RotateCharacter(Vector2 inputVector){
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = new Vector3(inputVector.x, 0, inputVector.y);
            Vector3 lookPosition = currentPosition + newPosition;
            transform.LookAt(lookPosition);
        }
        
    }
}
