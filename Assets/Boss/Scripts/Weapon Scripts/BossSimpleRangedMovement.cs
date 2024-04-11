using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleRangedMovement : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
    }
    void Update()
    {
        transform.localPosition += Vector3.forward * _bossStats.SimpleRangedProjectileMovementSpeed * Time.deltaTime;
    }
}
