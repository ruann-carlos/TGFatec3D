using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Combat
{
    public class Fighter : MonoBehaviour
    {
        Animator animator;
        bool isSwordColliding = false;
        bool isBlocking = false;
        [SerializeField] float timeBetweenAttacks = 1.5f;
        float timeSinceLastAttack = Mathf.Infinity; 

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public void Hit(float Damage, Collider target){
            if(isSwordColliding && target.gameObject != this.gameObject) {
                if(target.GetComponentInParent<Fighter>().isBlocking){
                    target.GetComponentInParent<Fighter>().ReceiveImpact();
                }else if(target.TryGetComponent<Health>(out Health enemy)){
                    enemy.ReceiveDamage(Damage);
                }
            }
        }

        public void ReceiveImpact(){
            animator.SetTrigger("blockImpact");
        }

        private void Update() {
            timeSinceLastAttack += Time.deltaTime;
            isBlocking = animator.GetBool("blocking");
        }

        public void SetAttackAnimation(){
            if(!IsRunningOrBlocking() && timeSinceLastAttack > timeBetweenAttacks){
                animator.SetTrigger("attack");
                timeSinceLastAttack = 0f;
            }
        }

        private bool IsRunningOrBlocking(){
            bool isRunning = animator.GetBool("running");
            if(isRunning || isBlocking) return true;
            return false;
        }
        
        public void SetDefenseAnimation(bool isBlocking){
            animator.SetBool("blocking",isBlocking);
            this.isBlocking = isBlocking;
        }

        public void SetSwordColliding(){
            isSwordColliding = true;
        }
        public void UnsetSwordColliding(){
            isSwordColliding = false;
        }
    }
}
