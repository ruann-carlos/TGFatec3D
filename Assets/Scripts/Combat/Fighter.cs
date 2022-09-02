using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Combat
{
    public class Fighter : MonoBehaviour
    {
        Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Hit(){
            print("Hitted");
        }
        public void SetAttackAnimation(){
            animator.SetTrigger("attack");
        }
    }
}
