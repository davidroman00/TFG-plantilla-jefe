using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReferences : MonoBehaviour
{
    [SerializeField]
    Transform _simpleRangedSpawnPoint1;
    [SerializeField]
    Transform _simpleRangedSpawnPoint2;
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
    GameObject _simpleRangedProjectile;
    [SerializeField]
    GameObject _patternRangedProjectile;
    [SerializeField]
    Transform _playerTransform; 
    public Transform PlayerTransform {get { return _playerTransform; } }
    public Transform SimpleRangedSpawnPoint1 { get { return _simpleRangedSpawnPoint1; } }
    public Transform SimpleRangedSpawnPoint2 { get { return _simpleRangedSpawnPoint2; } }
    public Transform PatternRangedSpawnPoint1 { get { return _patternRangedSpawnPoint1; } }
    public Transform PatternRangedSpawnPoint2 { get { return _patternRangedSpawnPoint2; } }
    public Transform PatternRangedSpawnPoint3 { get { return _patternRangedSpawnPoint3; } }
    public Transform PatternRangedSpawnPoint4 { get { return _patternRangedSpawnPoint4; } }
    public Transform PatternRangedSpawnPoint5 { get { return _patternRangedSpawnPoint5; } }
    
}
