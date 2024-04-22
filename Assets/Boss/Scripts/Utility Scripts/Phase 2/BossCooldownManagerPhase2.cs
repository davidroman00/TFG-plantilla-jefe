using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCooldownManagerPhase2 : MonoBehaviour
{
    BossStatsPhase2 _bossStats;
    float _lastSimpleMelee;
    float _lastPatternMelee;
    float _lastSimpleRanged;
    float _lastPatternRanged;
    float _lastArea;
    float _lastSimpleDash;
    float _lastBackDash;
    float _lastUltimate;
    public float LastSimpleMelee { set { _lastSimpleMelee = value; } }
    public float LastPatternMelee { set { _lastPatternMelee = value; } }
    public float LastSimpleRanged { set { _lastSimpleRanged = value; } }
    public float LastPatternRanged { set { _lastPatternRanged = value; } }
    public float LastArea { set { _lastArea = value; } }
    public float LastSimpleDash { set { _lastSimpleDash = value; } }
    public float LastBackDash { set { _lastBackDash = value; } }
    public float LastUltimate { set { _lastUltimate = value; } }
    void Awake()
    {
        _bossStats = GetComponent<BossStatsPhase2>();
    }
    public bool IsSimpleMeleeOnCooldown()
    {
        return Time.time < _lastSimpleMelee + _bossStats.SimpleMeleeCooldown;
    }
    public bool IsPatternMeleeOnCooldown()
    {
        return Time.time < _lastPatternMelee + _bossStats.PatternMeleeCooldown;
    }
    public bool IsSimpleRangedOnCooldown()
    {
        return Time.time < _lastSimpleRanged + _bossStats.SimpleRangedCooldown;
    }
    public bool IsPatternRangedOnCooldown()
    {
        return Time.time < _lastPatternRanged + _bossStats.PatternRangedCooldown;
    }
    public bool IsAreaOnCooldown()
    {
        return Time.time < _lastArea + _bossStats.AreaCooldown;
    }
    public bool IsSimpleDashOnCooldown()
    {
        return Time.time < _lastSimpleDash + _bossStats.SimpleDashCooldown;
    }
    public bool IsBackDashOnCooldown()
    {
        return Time.time < _lastBackDash + _bossStats.BackDashCooldown;
    }
    public bool IsUltimateOnCooldown()
    {
        return Time.time < _lastUltimate + _bossStats.UltimateCooldown;
    }
}
