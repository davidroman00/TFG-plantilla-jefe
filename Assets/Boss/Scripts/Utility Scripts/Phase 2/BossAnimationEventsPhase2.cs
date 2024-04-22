using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationEventsPhase2 : MonoBehaviour
{
    BossReferencesPhase2 _bossReferences;

    void Awake()
    {
        _bossReferences = GetComponent<BossReferencesPhase2>();
    }

    public void LeftMeleeAttackStart()
    {
        _bossReferences.LeftBossMeleeWeapon.enabled = true;
    }
    public void LeftMeleeAttackMid()
    {
        _bossReferences.LeftBossMeleeWeapon.enabled = false;
    }
    public void RightMeleeAttackStart()
    {
        _bossReferences.RightBossMeleeWeapon.enabled = true;
    }
    public void RightMeleeAttackMid()
    {
        _bossReferences.RightBossMeleeWeapon.enabled = false;
    }
    public void PatternFinalAttackStart()
    {
        GetComponentInChildren<BossBottomWeapon>().enabled = true;
    }
    public void PatternFinalAttackEnd()
    {
        GetComponentInChildren<BossBottomWeapon>().enabled = false;
    }
    public void UltimateAttackStart()
    {
        GetComponentInChildren<BossUltimateWeapon>().enabled = true;
    }
    public void LeftSimpleProjectileSpawn()
    {
        Instantiate(_bossReferences.SimpleProjectilePrefab, _bossReferences.LeftSimpleRangedSpawnPoint.position, _bossReferences.LeftSimpleRangedSpawnPoint.rotation);
    }
    public void RightSimpleProjectileSpawn()
    {
        Instantiate(_bossReferences.SimpleProjectilePrefab, _bossReferences.RightSimpleRangedSpawnPoint.position, _bossReferences.RightSimpleRangedSpawnPoint.rotation);
    }
    public void PatternProjectileSpawn1()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint1.position, _bossReferences.PatternRangedSpawnPoint1.rotation);
    }
    public void PatternProjectileSpawn2()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint2.position, _bossReferences.PatternRangedSpawnPoint2.rotation);
    }
    public void PatternProjectileSpawn3()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint3.position, _bossReferences.PatternRangedSpawnPoint3.rotation);
    }
    public void PatternProjectileSpawn4()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint4.position, _bossReferences.PatternRangedSpawnPoint4.rotation);
    }
    public void PatternProjectileSpawn5()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint5.position, _bossReferences.PatternRangedSpawnPoint5.rotation);
    }
    public void AreaSpawn()
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
}
