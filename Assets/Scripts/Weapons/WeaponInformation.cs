using System.Collections;
using System.Collections.Generic;
using TG.Combat;
using UnityEngine;
using UnityEngine.EventSystems;
namespace TG.Weapons
{
    public class WeaponInformation : MonoBehaviour
    {
        [SerializeField] public float weaponDamage;
    
        private void OnTriggerEnter(Collider other) {
            GetComponentInParent<Fighter>().Hit(weaponDamage, other);
        }
    }
}
