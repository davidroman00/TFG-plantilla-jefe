using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPatternRangedWeapon : MonoBehaviour
{
    BossStatsPhase2 _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStatsPhase2>();
        Destroy(gameObject, 12f);
    }
    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player"){
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.PatternRangedProjectileDamage);
            Destroy(gameObject);
        }        
    }
}
