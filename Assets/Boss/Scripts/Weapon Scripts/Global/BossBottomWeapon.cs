using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBottomWeapon : MonoBehaviour
{
    BossStatsPhase2 _bossStats;
    void Awake()
    {
        _bossStats = GetComponentInParent<BossStatsPhase2>();
    }
    void OnTriggerEnter(Collider collider) {
        if (this.enabled && collider.GetComponent<CharacterHealthManager>()){
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.PatternMeleeFinalAttackDamage);
            this.enabled = false; 
        }
    }
}
