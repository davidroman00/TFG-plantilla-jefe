using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeWeapon : MonoBehaviour
{
    BossStatsPhase2 _bossStats;
    void Awake()
    {
        _bossStats = GetComponentInParent<BossStatsPhase2>();
    }
    void OnTriggerEnter(Collider collider) {
        if (this.enabled == true && collider.GetComponent<CharacterHealthManager>()){
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.SimpleMeleeAttackDamage);
            this.enabled = false;
        }
    }
}
