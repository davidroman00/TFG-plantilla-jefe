using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleRangedWeapon : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
        Destroy(gameObject, 2.5f);
    }
    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player"){
            collider.GetComponent<CharacterHealthManager>().PlayerCurrentHealthManager(_bossStats.SimpleRangedProjectileDamage);
        }
        Destroy(gameObject);
    }
}
