using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Weapons
{
    public class WeaponInformation : MonoBehaviour
    {
        [SerializeField] public float weaponDamage;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private void OnTriggerEnter(Collider other) {
            print("colidiu");
            other.GetComponent<Animator>().SetTrigger("damage");
        }
    }
}
