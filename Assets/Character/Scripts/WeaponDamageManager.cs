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

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.GetComponent<BossHealthManager>() && this.enabled == true)
        {
            enemy.GetComponent<BossHealthManager>().CurrentHealthManager(_characterStats.AttackDamage);
        }
    }
}
