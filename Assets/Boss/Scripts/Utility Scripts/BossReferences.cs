using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReferences : MonoBehaviour
{
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
    Transform _simpleRangedProjectile;
    [SerializeField]
    Transform _patternRangedProjectile;
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
    [SerializeField]
    Transform _playerTransform; 
    public Transform LeftSimpleRangedSpawnPoint { get { return _leftSimpleRangedSpawnPoint; } }
    public Transform RightSimpleRangedSpawnPoint { get { return _rightSimpleRangedSpawnPoint; } }
    public Transform PatternRangedSpawnPoint1 { get { return _patternRangedSpawnPoint1; } }
    public Transform PatternRangedSpawnPoint2 { get { return _patternRangedSpawnPoint2; } }
    public Transform PatternRangedSpawnPoint3 { get { return _patternRangedSpawnPoint3; } }
    public Transform PatternRangedSpawnPoint4 { get { return _patternRangedSpawnPoint4; } }
    public Transform PatternRangedSpawnPoint5 { get { return _patternRangedSpawnPoint5; } }
    public Transform LeftAreaSpawnPoint { get { return _leftAreaSpawnPoint; } }
    public Transform RightAreaSpawnPoint { get { return _rightAreaSpawnPoint; } }
    public GameObject SimpleProjectilePrefab { get { return _simpleProjectilePrefab; } }
    public GameObject PatternProjectilePrefab { get {return _patternProjectilePrefab; } }
    public GameObject AreaPrefab { get { return _areaPrefab; } }
    public Transform PlayerTransform {get { return _playerTransform; } }
}
