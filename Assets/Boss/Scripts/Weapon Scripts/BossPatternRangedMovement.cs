using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternRangedMovement : MonoBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
        _bossReferences = FindFirstObjectByType<BossReferences>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _bossReferences.PlayerTransform.position, _bossStats.PatternRangedProjectileMovementSpeed * Time.deltaTime);
    }
}
