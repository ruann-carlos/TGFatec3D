using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float totalHealth = 20;
        float currentHealth;
        bool isDead = false;

        private void Awake() {
            currentHealth = totalHealth;
        }
        public void ReceiveDamage(float Damage){
            if(!isDead){
                currentHealth -= Damage;
                GetComponent<Animator>().SetTrigger("damage");
            }
            CheckDeath();
        }

        private void CheckDeath(){
            if(currentHealth <= 0) {
                currentHealth = 0;
                Death();
            }
        }
        
        private void Death(){
            if(!isDead) GetComponent<Animator>().SetTrigger("death");
            isDead = true;
        }
    }
}
