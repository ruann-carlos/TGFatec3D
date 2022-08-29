using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5;
        Rigidbody rigidBody;

        private void Start() {
            rigidBody = GetComponent<Rigidbody>();
        }

        void Update()
        {
        
        }

        public void Move(Vector3 direction){
            print(direction.normalized);
            rigidBody.AddForce(new Vector3(direction.x, 0, direction.y) * movementSpeed, ForceMode.Force);
        }
    }
}
