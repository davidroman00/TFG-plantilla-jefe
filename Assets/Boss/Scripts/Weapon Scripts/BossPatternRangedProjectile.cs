using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPatternRangedProjectile : MonoBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
        _bossReferences = FindFirstObjectByType<BossReferences>();
        Destroy(gameObject, _bossStats.PatternRangedProjectileLifetime);
    }
    void Update()
    {
        //This object moves towards the player.
        transform.position = Vector3.MoveTowards(transform.position, _bossReferences.PlayerTransform.position, _bossStats.PatternRangedProjectileMovementSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.PatternRangedProjectileDamage);
            Destroy(gameObject);
        }        
    }
}
