using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossPositionToLookAt : MonoBehaviour
{
    Rigidbody _bossRigidbody;
    Transform _playerTransform;
    Vector3 _playerPosition;
    void Awake()
    {
        _playerTransform = GetComponent<BossReferences>().PlayerTransform;
        _bossRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleBossRotation();
    }
    void HandleBossRotation()
    {
        _playerPosition.x = _playerTransform.position.x;
        _playerPosition.z = _playerTransform.position.z;
        Quaternion appliedRotation = Quaternion.LookRotation(_playerPosition, Vector3.up);
        _bossRigidbody.MoveRotation(appliedRotation);
    }
}

