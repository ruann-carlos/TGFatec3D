using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float playerWalkingSpeed = 3;
        [SerializeField] float playerRunningSpeed = 5;
        float rotationFactor = 15;

        public void MoveCharacterRelativeToCamera(Vector3 inputVector, bool isRunning){
            
            Vector3 forwardCamera = Camera.main.transform.forward;
            Vector3 rightCamera = Camera.main.transform.right;
            forwardCamera.y = 0;
            rightCamera.y = 0;
            forwardCamera = forwardCamera.normalized;
            rightCamera = rightCamera.normalized;

            Vector3 forwardRelativeVertical = inputVector.z * forwardCamera;
            Vector3 rightRelativeHorizontal = inputVector.x * rightCamera;
            Vector3 cameraRelativeDirection = forwardRelativeVertical + rightRelativeHorizontal;
            if(isRunning){
                this.transform.Translate(cameraRelativeDirection * Time.deltaTime * playerRunningSpeed, Space.World);
            }else{
                this.transform.Translate(cameraRelativeDirection * Time.deltaTime * playerWalkingSpeed, Space.World);
            }

        }

        public void RotateCharacter(Vector3 inputVector, bool isMoving){
            Vector3 angleToLook;
            angleToLook.x = inputVector.x;
            angleToLook.y = 0;
            angleToLook.z = inputVector.z;
            Quaternion currentRotation = transform.rotation;
            if(isMoving){
                Quaternion targetRotation = Quaternion.LookRotation(angleToLook);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactor * Time.deltaTime);
            }
        }
        
    }
}
