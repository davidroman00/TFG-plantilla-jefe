using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleRangedWeapon : MonoBehaviour
{
    BossStatsPhase2 _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStatsPhase2>();
        Destroy(gameObject, 2.5f);
    }
    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player"){
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.SimpleRangedProjectileDamage);
            Destroy(gameObject);
        }
    }
}
