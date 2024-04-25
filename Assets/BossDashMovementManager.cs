using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDashMovementManager : StateMachineBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    Rigidbody _rigidbody;
    Transform _playerTransform;
    Vector3 _playerPosition;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
        _rigidbody = animator.GetComponent<Rigidbody>();
        _playerTransform = animator.GetComponent<BossReferences>().PlayerTransform;

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_bossReferences.IsActualDashActive)
        {
            _playerPosition.x = _playerTransform.position.x;
            _playerPosition.z = _playerTransform.position.z;
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, _playerPosition, _bossStats.DashMovementSpeed * Time.deltaTime);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("dash");
    }
}
