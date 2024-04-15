using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDamageManager : MonoBehaviour
{
    CharacterStats _characterStats;
    void Awake()
    {
        _characterStats = GetComponentInParent<CharacterStats>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<EnemyHealthManager>() && this.enabled)
        {
            collider.GetComponent<EnemyHealthManager>().EnemyRecieveDamage(_characterStats.AttackDamage);
            this.enabled = false;
        }
    }
}
