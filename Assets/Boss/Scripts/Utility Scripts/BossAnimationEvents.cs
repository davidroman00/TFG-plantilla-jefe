using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    BossReferences _bossReferences;
    BossMeleeWeapon _bossMeleeWeapon;
    Animator _animator;
    int _currentRangedPatternLoops;
    int _currentAreaLoops;
    int _currentUltimateBreakLoops;
    void Awake()
    {
        _bossReferences = GetComponent<BossReferences>();
        _bossMeleeWeapon = GetComponentInChildren<BossMeleeWeapon>();
        _animator = GetComponent<Animator>();
    }

    public void SimpleMeleeAttackStart()
    {
        _bossMeleeWeapon.enabled = true;
    }
    public void SimpleMeleeAttackMid()
    {
        _bossMeleeWeapon.enabled = false;
    }
    public void PatternFinalAttackStart()
    {
        _bossMeleeWeapon.enabled = true;
        _bossReferences.IsLastMeleePatternAttack = true;
    }
    public void PatternFinalAttackEnd()
    {
        _bossMeleeWeapon.enabled = false;
        _bossReferences.IsLastMeleePatternAttack = false;
    }
    public void UltimateAttackStart()
    {
        Instantiate(_bossReferences.UltimateWeaponPrefab, _bossReferences.LeftSimpleRangedSpawnPoint.position, _bossReferences.LeftSimpleRangedSpawnPoint.rotation);
    }
    public void UltimateBreakManager()
    {
        _currentUltimateBreakLoops++;
        if (_currentUltimateBreakLoops >= 5)
        {
            _animator.SetTrigger("ultimateBreakEnd");
            _currentUltimateBreakLoops = 0;
        }
    }
    public void LeftSimpleProjectileSpawn()
    {
        Instantiate(_bossReferences.SimpleProjectilePrefab, _bossReferences.LeftSimpleRangedSpawnPoint.position, _bossReferences.LeftSimpleRangedSpawnPoint.rotation);
    }
    public void RightSimpleProjectileSpawn()
    {
        Instantiate(_bossReferences.SimpleProjectilePrefab, _bossReferences.RightSimpleRangedSpawnPoint.position, _bossReferences.RightSimpleRangedSpawnPoint.rotation);
    }
    public void PatternProjectileSpawnManager()
    {
        _currentRangedPatternLoops++;
        switch (_currentRangedPatternLoops)
        {
            case 1:
                PatternProjectileSpawn1();
                break;
            case 2:
                PatternProjectileSpawn2();
                break;
            case 3:
                PatternProjectileSpawn3();
                break;
            case 4:
                PatternProjectileSpawn4();
                break;
            case 5:
                PatternProjectileSpawn5();
                _animator.SetTrigger("rangedPatternEnd");
                _currentRangedPatternLoops = 0;
                break;
        }
    }
    void PatternProjectileSpawn1()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint1.position, _bossReferences.PatternRangedSpawnPoint1.rotation);
    }
    void PatternProjectileSpawn2()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint2.position, _bossReferences.PatternRangedSpawnPoint2.rotation);
    }
    void PatternProjectileSpawn3()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint3.position, _bossReferences.PatternRangedSpawnPoint3.rotation);
    }
    void PatternProjectileSpawn4()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint4.position, _bossReferences.PatternRangedSpawnPoint4.rotation);
    }
    void PatternProjectileSpawn5()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint5.position, _bossReferences.PatternRangedSpawnPoint5.rotation);
    }
    public void AreaSpawnManager()
    {
        _currentAreaLoops++;
        if (_currentAreaLoops >= 3)
        {
            AreaSpawn();
            _animator.SetTrigger("areaEnd");
            _currentAreaLoops = 0;
        }
    }
    void AreaSpawn()
    {
        if (Random.value > .5)
        {
            Instantiate(_bossReferences.AreaPrefab, _bossReferences.LeftAreaSpawnPoint.position, _bossReferences.LeftAreaSpawnPoint.rotation);
        }
        else
        {
            Instantiate(_bossReferences.AreaPrefab, _bossReferences.RightAreaSpawnPoint.position, _bossReferences.RightAreaSpawnPoint.rotation);
        }
    }
    public void ActualBackdashStart()
    {
        _bossReferences.IsActualBackdashActive = true;
    }
    public void ActualBackdashEnd()
    {
        _bossReferences.IsActualBackdashActive = false;
    }
    public void ActualDashStart()
    {
        _bossReferences.IsActualDashActive = true;
    }
    public void ActualDashEnd()
    {
        _bossReferences.IsActualDashActive = false;
    }
    public void PhaseChange()
    {
        _bossReferences.BossPhase1.SetActive(false);
        _bossReferences.BossPhase2.SetActive(true);
    }
}
