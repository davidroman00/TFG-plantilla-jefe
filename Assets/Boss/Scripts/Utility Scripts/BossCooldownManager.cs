using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCooldownManager : MonoBehaviour
{
    float _lastSimpleMelee;
    float _lastPatternMelee;
    float _lastSimpleRanged;
    float _lastPatternRanged;
    float _lastArea;
    float _lastSimpleDash;
    float _lastZigZagDash;
    float _lastBackDash;
    BossStats _bossStats;
    public float LastSimpleMelee { set { _lastSimpleMelee = value; } }
    public float LastPatternMelee { set { _lastPatternMelee = value; } }
    public float LastSimpleRanged { set { _lastSimpleRanged = value; } }
    public float LastPatternRanged { set { _lastPatternRanged = value; } }
    public float LastArea { set { _lastArea = value; } }
    public float LastSimpleDash { set { _lastSimpleDash = value; } }
    public float LastZigZagDash { set { _lastZigZagDash = value; } }
    public float LastBackDash { set { _lastBackDash = value; } }
    void Awake()
    {
        _bossStats = GetComponent<BossStats>();
    }
    void Update(){
        Debug.Log("Simple anged on CD?: " + IsSimpleRangedOnCooldown());
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
    public bool IsZigZagDashOnCooldown()
    {
        return Time.time < _lastZigZagDash + _bossStats.ZigZagDashCooldown;
    }
    public bool IsBackDashOnCooldown()
    {
        return Time.time < _lastBackDash + _bossStats.BackDashCooldown;
    }
}
