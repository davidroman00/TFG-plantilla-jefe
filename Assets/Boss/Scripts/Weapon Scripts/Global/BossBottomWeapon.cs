using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBottomWeapon : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = GetComponentInParent<BossStats>();
    }
    void OnTriggerEnter(Collider collider) {
        if (this.enabled && collider.GetComponent<CharacterHealthManager>()){
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.PatternMeleeFinalAttackDamage);
            this.enabled = false; 
        }
    }
}
