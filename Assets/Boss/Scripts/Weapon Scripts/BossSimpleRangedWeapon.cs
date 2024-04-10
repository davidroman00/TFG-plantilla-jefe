using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleRangedWeapon : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
    }
    void OnTriggerEnter(Collider collider) {
        if (this.enabled == true && collider.GetComponent<CharacterHealthManager>()){
            collider.GetComponent<CharacterHealthManager>().PlayerCurrentHealthManager(_bossStats.SimpleRangedProjectileDamage);
        }
    }
}
