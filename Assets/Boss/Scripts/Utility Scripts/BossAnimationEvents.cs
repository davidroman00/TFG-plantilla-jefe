using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    [SerializeField]
    Transform _leftSimpleProjectileSpawnPoint;
    [SerializeField]
    Transform _rightSimpleProjectileSpawnPoint;
    [SerializeField]
    Transform _patternProjectileSpawnPoint1;
    [SerializeField]
    Transform _patternProjectileSpawnPoint2;
    [SerializeField]
    Transform _patternProjectileSpawnPoint3;
    [SerializeField]
    Transform _patternProjectileSpawnPoint4;
    [SerializeField]
    Transform _patternProjectileSpawnPoint5;
    [SerializeField]
    Transform _leftAreaSpawnPoint;
    [SerializeField]
    Transform _rightAreaSpawnPoint;
    [SerializeField]
    GameObject _simpleProjectilePrefab;
    [SerializeField]
    GameObject _patternProjectilePrefab;
    [SerializeField]
    GameObject _areaPrefab;

    public void NormalMeleeAttackStart()
    {
        GetComponentInChildren<BossMeleeWeapon>().enabled = true;
    }
    public void NormalMeleeAttackMid()
    {
        GetComponentInChildren<BossMeleeWeapon>().enabled = false;
    }
    public void LeftSimpleProjectileSpawn()
    {
        Instantiate(_simpleProjectilePrefab, _leftSimpleProjectileSpawnPoint);
    }
    public void RightSimpleProjectileSpawn()
    {
        Instantiate(_simpleProjectilePrefab, _rightSimpleProjectileSpawnPoint);
    }
    public void PatternProjectileSpawn1()
    {
        Instantiate(_patternProjectilePrefab, _patternProjectileSpawnPoint1);
    }
    public void PatternProjectileSpawn2()
    {
        Instantiate(_patternProjectilePrefab, _patternProjectileSpawnPoint2);
    }
    public void PatternProjectileSpawn3()
    {
        Instantiate(_patternProjectilePrefab, _patternProjectileSpawnPoint3);
    }
    public void PatternProjectileSpawn4()
    {
        Instantiate(_patternProjectilePrefab, _patternProjectileSpawnPoint4);
    }
    public void PatternProjectileSpawn5()
    {
        Instantiate(_patternProjectilePrefab, _patternProjectileSpawnPoint5);
    }
    public void AreaSpawn()
    {
        if (Random.value > .5)
        {
            Instantiate(_areaPrefab, _leftAreaSpawnPoint);
        }
        else
        {
            Instantiate(_areaPrefab, _rightAreaSpawnPoint);
        }
    }
}
