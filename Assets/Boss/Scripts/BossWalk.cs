using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalk : StateMachineBehaviour
{
    BossStats _bossStats;
    Rigidbody _bossRigidbody;
    Transform _playerTransform;
    Vector3 _playerPosition;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _bossRigidbody = animator.GetComponent<Rigidbody>();
        _playerTransform = animator.GetComponent<BossReferences>().PlayerTransform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BossHandleMovement();
    }
    void BossHandleMovement()
    {
        _playerPosition.x = _playerTransform.position.x;
        _playerPosition.z = _playerTransform.position.z;
        Vector3 bossDirectionVector = Vector3.MoveTowards(_bossRigidbody.position, _playerPosition, _bossStats.BossMovementSpeed * Time.deltaTime);
        _bossRigidbody.MovePosition(bossDirectionVector);
    }
}
