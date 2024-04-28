using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleRangedProjectile : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
        Destroy(gameObject, _bossStats.SimpleRangedProjectileLifetime);
    }
    void Update()
    {
        //This object moves forward.
        transform.Translate(_bossStats.SimpleRangedProjectileMovementSpeed * Time.deltaTime * Vector3.forward);
    }
    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.SimpleRangedProjectileDamage);
            Destroy(gameObject);
        }
    }
}
