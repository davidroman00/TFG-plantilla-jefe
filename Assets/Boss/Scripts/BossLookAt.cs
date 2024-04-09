using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : StateMachineBehaviour
{
    Rigidbody _bossRigidbody;
    Transform _playerTransform;
    Vector3 _playerPosition;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerTransform = animator.GetComponent<BossReferences>().PlayerTransform;
        _bossRigidbody = animator.GetComponent<Rigidbody>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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
