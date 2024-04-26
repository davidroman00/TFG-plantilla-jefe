using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReferences : MonoBehaviour
{//el hecho de que haya algunos 'none' en el inspector se debe a que, en esa fase, esos objetos no son necesarios
    [SerializeField]
    Transform _leftSimpleRangedSpawnPoint;
    [SerializeField]
    Transform _rightSimpleRangedSpawnPoint;
    [SerializeField]
    Transform _patternRangedSpawnPoint1;
    [SerializeField]
    Transform _patternRangedSpawnPoint2;
    [SerializeField]
    Transform _patternRangedSpawnPoint3;
    [SerializeField]
    Transform _patternRangedSpawnPoint4;
    [SerializeField]
    Transform _patternRangedSpawnPoint5;
    [SerializeField]
    Transform _leftAreaSpawnPoint;
    [SerializeField]
    Transform _rightAreaSpawnPoint;
    [SerializeField]
    Transform _ultimateBossPosition;
    [SerializeField]
    Transform _ultimateWeaponSpawnPoint;
    [SerializeField]
    Transform _ultimateDeviceSpawnPoint;
    [SerializeField]
    GameObject _simpleProjectilePrefab;
    [SerializeField]
    GameObject _patternProjectilePrefab;
    [SerializeField]
    GameObject _areaPrefab;
    [SerializeField]
    GameObject _ultimateWeaponPrefab;
    [SerializeField]
    GameObject _ultimateDevicePrefab;
    [SerializeField]
    Transform _playerTransform; 
    [SerializeField]
    GameObject _bossPhase1;
    [SerializeField]
    GameObject _bossPhase2;
    bool _isLastMeleePatternAttack;
    bool _isActualBackdashActive;
    bool _isActualDashActive;
    public Transform LeftSimpleRangedSpawnPoint { get { return _leftSimpleRangedSpawnPoint; } }
    public Transform RightSimpleRangedSpawnPoint { get { return _rightSimpleRangedSpawnPoint; } }
    public Transform PatternRangedSpawnPoint1 { get { return _patternRangedSpawnPoint1; } }
    public Transform PatternRangedSpawnPoint2 { get { return _patternRangedSpawnPoint2; } }
    public Transform PatternRangedSpawnPoint3 { get { return _patternRangedSpawnPoint3; } }
    public Transform PatternRangedSpawnPoint4 { get { return _patternRangedSpawnPoint4; } }
    public Transform PatternRangedSpawnPoint5 { get { return _patternRangedSpawnPoint5; } }
    public Transform LeftAreaSpawnPoint { get { return _leftAreaSpawnPoint; } }
    public Transform RightAreaSpawnPoint { get { return _rightAreaSpawnPoint; } }
    public Transform UltimateBossPosition { get { return _ultimateBossPosition; } }
    public Transform UltimateWeaponSpawnPoint { get { return _ultimateWeaponSpawnPoint; } }
    public Transform UltimateDeviceSpawnPoint { get {return _ultimateDeviceSpawnPoint; } }
    public GameObject SimpleProjectilePrefab { get { return _simpleProjectilePrefab; } }
    public GameObject PatternProjectilePrefab { get {return _patternProjectilePrefab; } }
    public GameObject AreaPrefab { get { return _areaPrefab; } }
    public GameObject UltimateWeaponPrefab { get { return _ultimateWeaponPrefab; } }
    public GameObject UltimateDevicePrefab { get { return _ultimateDevicePrefab; } }
    public Transform PlayerTransform { get { return _playerTransform; } }
    public GameObject BossPhase1 { get { return _bossPhase1; } }
    public GameObject BossPhase2 { get { return _bossPhase2; } }
    public bool IsLastMeleePatternAttack { get { return _isLastMeleePatternAttack; } set { _isLastMeleePatternAttack = value; } }
    public bool IsActualBackdashActive { get { return _isActualBackdashActive; } set { _isActualBackdashActive = value; } }
    public bool IsActualDashActive { get { return _isActualDashActive; } set { _isActualDashActive = value; } }
}
