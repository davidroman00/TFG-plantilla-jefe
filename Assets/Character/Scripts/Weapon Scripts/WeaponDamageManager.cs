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
        if (collider.GetComponent<BossHealthManager>() && this.enabled)
        {
            collider.GetComponent<BossHealthManager>().EnemyRecieveDamage(_characterStats.AttackDamage);
            this.enabled = false;
        }
    }
}
