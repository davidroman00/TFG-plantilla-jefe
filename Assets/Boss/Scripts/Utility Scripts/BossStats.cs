using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
   [SerializeField]
   float _simpleMeleeAttackDamage = 5f;
   [SerializeField]
   float _patternMeleeFinalAttackDamage = 15f;
   [SerializeField]
   float _simpleRangedProjectileDamage = 5f;
   [SerializeField]
   float _patternRangedProjectileDamage = 10f;
   [SerializeField]
   float _areaAttackDamagePerSecond = 2.5f;
   [SerializeField]
   float _ultimateAttackDamage = 999999f;
   [SerializeField]
   float _areaDuration = 20f;
   [SerializeField]
   float _simpleMeleeCooldown = 3f;
   [SerializeField]
   float _patternMeleeCooldown = 20f;
   [SerializeField]
   float _simpleRangedCooldown = 10f;
   [SerializeField]
   float _patternRangedCooldown = 30f;
   [SerializeField]
   float _areaCooldown = 45f;
   [SerializeField]
   float _simpleDashCooldown = 15f;
   [SerializeField]
   float _zigZagDashCooldown = 20f;
   [SerializeField]
   float _backDashCooldown = 12f;
   [SerializeField]
   float _meleeMaxDistance = 2f;
   [SerializeField]
   float _rangedMinDistance = 7f;
   [SerializeField]
   float _dashMinDistance = 8f;
   [SerializeField]
   float _dashMaxDistance = 6f;
   [SerializeField]
   float _simpleRangedProjectileMovementSpeed = 25f;
   [SerializeField]
   float _patternRangedProjectileMovementSpeed = 5f;
   [SerializeField]
   float _bossMovementSpeed = 5f;
   [SerializeField]
   int _bossMaxUltimateUses = 1;
   [SerializeField]
   float _bossUltimateHPThreshold = 200f;
   [SerializeField]
   float _bossMaxHP = 1000f;

   public float SimpleMeleeAttackDamage { get { return _simpleMeleeAttackDamage; } }
   public float PatternMeleeFinalAttackDamage { get { return _patternMeleeFinalAttackDamage; } }
   public float SimpleRangedProjectileDamage { get { return _simpleRangedProjectileDamage; } }
   public float PatternRangedProjectileDamage { get { return _patternRangedProjectileDamage; } }
   public float AreaAttackDamagePerSecond { get { return _areaAttackDamagePerSecond; } }
   public float UltimateAttackDamage { get { return _ultimateAttackDamage; } }
   public float AreaDuration { get { return _areaDuration; } }
   public float SimpleMeleeCooldown { get { return _simpleMeleeCooldown; } }
   public float PatternMeleeCooldown { get { return _patternMeleeCooldown; } }
   public float SimpleRangedCooldown { get { return _simpleRangedCooldown; } }
   public float PatternRangedCooldown { get { return _patternRangedCooldown; } }
   public float AreaCooldown { get { return _areaCooldown; } }
   public float SimpleDashCooldown { get { return _simpleDashCooldown; } }
   public float ZigZagDashCooldown { get { return _zigZagDashCooldown; } }
   public float BackDashCooldown { get { return _backDashCooldown; } }
   public float MeleeMaxDistance { get { return _meleeMaxDistance; } }
   public float RangedMinDistance { get { return _rangedMinDistance; } }
   public float DashMinDistance { get { return _dashMinDistance; } }
   public float DashMaxDistance { get { return _dashMaxDistance; } }
   public float SimpleRangedProjectileMovementSpeed { get { return _simpleRangedProjectileMovementSpeed; } }
   public float PatternRangedProjectileMovementSpeed { get { return _patternRangedProjectileMovementSpeed; } }
   public float BossMovementSpeed { get { return _bossMovementSpeed; } }
   public int BossMaxUltimateUses { get { return _bossMaxUltimateUses; } }
   public float BossUltimateHPThreshold { get { return _bossUltimateHPThreshold; } }
   public float BossMaxHP { get { return _bossMaxHP; } }
}
