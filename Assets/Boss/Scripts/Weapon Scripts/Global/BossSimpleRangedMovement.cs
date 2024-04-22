using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleRangedMovement : MonoBehaviour
{
    BossStatsPhase2 _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStatsPhase2>();
    }
    void Update()
    {
        transform.Translate(Vector3.forward * _bossStats.SimpleRangedProjectileMovementSpeed * Time.deltaTime);
    }
}
