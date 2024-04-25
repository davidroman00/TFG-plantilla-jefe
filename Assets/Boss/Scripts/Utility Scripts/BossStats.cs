using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{//el hecho de que haya algunos valores a 0 en el inspector se debe a que, en esa fase, son estadisticas que no se necesitan
   [SerializeField]
   float _simpleMeleeAttackDamage;
   [SerializeField]
   float _patternMeleeFinalAttackDamage;
   [SerializeField]
   float _simpleRangedProjectileDamage;
   [SerializeField]
   float _patternRangedProjectileDamage;
   [SerializeField]
   float _areaAttackDamagePerSecond;
   [SerializeField]
   float _ultimateAttackDamage;
   [SerializeField]
   float _areaDuration;
   [SerializeField]
   float _simpleMeleeCooldown;
   [SerializeField]
   float _patternMeleeCooldown;
   [SerializeField]
   float _simpleRangedCooldown;
   [SerializeField]
   float _patternRangedCooldown;
   [SerializeField]
   float _areaCooldown;
   [SerializeField]
   float _simpleDashCooldown;
   [SerializeField]
   float _backDashCooldown;
   [SerializeField]
   float _meleeMaxDistance;
   [SerializeField]
   float _rangedMinDistance;
   [SerializeField]
   float _dashMinDistance;
   [SerializeField]
   float _dashMaxDistance;
   [SerializeField]
   float _dashMovementSpeed;
   [SerializeField]
   float _simpleRangedProjectileMovementSpeed;
   [SerializeField]
   float _patternRangedProjectileMovementSpeed;
   [SerializeField]
   float _bossMovementSpeed;
   [SerializeField]
   int _bossMaxUltimateUses;
   [SerializeField]
   float _bossUltimateHPThreshold;
   [SerializeField]
   float _bossMaxHP;

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
   public float BackDashCooldown { get { return _backDashCooldown; } }
   public float MeleeMaxDistance { get { return _meleeMaxDistance; } }
   public float RangedMinDistance { get { return _rangedMinDistance; } }
   public float DashMinDistance { get { return _dashMinDistance; } }
   public float DashMaxDistance { get { return _dashMaxDistance; } }
   public float DashMovementSpeed { get { return _dashMovementSpeed; } }
   public float SimpleRangedProjectileMovementSpeed { get { return _simpleRangedProjectileMovementSpeed; } }
   public float PatternRangedProjectileMovementSpeed { get { return _patternRangedProjectileMovementSpeed; } }
   public float BossMovementSpeed { get { return _bossMovementSpeed; } }
   public int BossMaxUltimateUses { get { return _bossMaxUltimateUses; } }
   public float BossUltimateHPThreshold { get { return _bossUltimateHPThreshold; } }
   public float BossMaxHP { get { return _bossMaxHP; } }
}
