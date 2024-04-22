using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternRangedMovement : MonoBehaviour
{
    BossStatsPhase2 _bossStats;
    BossReferencesPhase2 _bossReferences;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStatsPhase2>();
        _bossReferences = FindFirstObjectByType<BossReferencesPhase2>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _bossReferences.PlayerTransform.position, _bossStats.PatternRangedProjectileMovementSpeed * Time.deltaTime);
    }
}
