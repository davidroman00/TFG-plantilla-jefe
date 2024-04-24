using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeWeapon : MonoBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    void Awake()
    {
        _bossStats = GetComponentInParent<BossStats>();
        _bossReferences = GetComponentInParent<BossReferences>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (this.enabled == true && collider.GetComponent<CharacterHealthManager>())
        {
            if (_bossReferences.IsLastMeleePatternAttack)
            {
                collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.PatternMeleeFinalAttackDamage);
            }
            else
            {
                collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.SimpleMeleeAttackDamage);
            }
            this.enabled = false;
        }
    }
}
