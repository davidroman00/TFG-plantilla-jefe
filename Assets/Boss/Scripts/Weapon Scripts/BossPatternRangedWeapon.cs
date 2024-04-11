using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPatternRangedWeapon : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
        Destroy(gameObject, 10f);
    }
    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player"){
            collider.GetComponent<CharacterHealthManager>().PlayerCurrentHealthManager(_bossStats.PatternRangedProjectileDamage);
        }
        Destroy(gameObject);
    }
}
