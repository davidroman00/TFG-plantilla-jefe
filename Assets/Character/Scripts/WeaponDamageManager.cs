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
        if (collider.GetComponent<BossHealthManager>() && this.enabled == true)
        {
            collider.GetComponent<BossHealthManager>().CurrentHealthManager(_characterStats.AttackDamage);
        }
    }
}
