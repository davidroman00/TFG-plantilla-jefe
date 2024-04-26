using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleRangedProjectile : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
        Destroy(gameObject, 2.5f);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * _bossStats.SimpleRangedProjectileMovementSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player"){
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.SimpleRangedProjectileDamage);
            Destroy(gameObject);
        }
    }
}
