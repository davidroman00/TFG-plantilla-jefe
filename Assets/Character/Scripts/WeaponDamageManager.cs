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
        if (collider.GetComponent<EnemyHealthManager>() && this.enabled == true)
        {
            collider.GetComponent<EnemyHealthManager>().CurrentHealthManager(_characterStats.AttackDamage);
        }
    }
}
