using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    BossReferences _bossReferences;

    void Awake()
    {
        _bossReferences = GetComponent<BossReferences>();
    }

    public void NormalMeleeAttackStart()
    {
        GetComponentInChildren<BossMeleeWeapon>().enabled = true;
    }
    public void NormalMeleeAttackMid()
    {
        GetComponentInChildren<BossMeleeWeapon>().enabled = false;
    }
    public void UltimateAttackStart()
    {
        GetComponentInChildren<BossUltimateWeapon>().enabled = true;
    }
    public void PatternFinalAttackStart()
    {
        GetComponentInChildren<BossBottomWeapon>().enabled = true;
    }
    public void PatternFinalAttackEnd()
    {
        GetComponentInChildren<BossBottomWeapon>().enabled = false;
    }
    public void LeftSimpleProjectileSpawn()
    {
        Instantiate(_bossReferences.SimpleProjectilePrefab, _bossReferences.LeftSimpleRangedSpawnPoint);
    }
    public void RightSimpleProjectileSpawn()
    {
        Instantiate(_bossReferences.SimpleProjectilePrefab, _bossReferences.RightSimpleRangedSpawnPoint);
    }
    public void PatternProjectileSpawn1()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint1);
    }
    public void PatternProjectileSpawn2()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint2);
    }
    public void PatternProjectileSpawn3()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint3);
    }
    public void PatternProjectileSpawn4()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint4);
    }
    public void PatternProjectileSpawn5()
    {
        Instantiate(_bossReferences.PatternProjectilePrefab, _bossReferences.PatternRangedSpawnPoint5);
    }
    public void AreaSpawn()
    {
        if (Random.value > .5)
        {
            Instantiate(_bossReferences.AreaPrefab, _bossReferences.LeftAreaSpawnPoint);
        }
        else
        {
            Instantiate(_bossReferences.AreaPrefab, _bossReferences.RightAreaSpawnPoint);
        }
    }
}
