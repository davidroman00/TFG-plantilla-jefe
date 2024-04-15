using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUltimateWeapon : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = GetComponentInParent<BossStats>();
    }
    void OnTriggerEnter(Collider collider) {
        if (this.enabled == true && collider.GetComponent<CharacterHealthManager>()){
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.UltimateAttackDamage);
        }
    }
}
