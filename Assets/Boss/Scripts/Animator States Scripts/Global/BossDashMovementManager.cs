using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDashMovementManager : StateMachineBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    Rigidbody _rigidbody;
    Vector3 _playerPosition;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
        _rigidbody = animator.GetComponent<Rigidbody>();

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerPosition.x = _bossReferences.PlayerTransform.position.x;
        _playerPosition.z = _bossReferences.PlayerTransform.position.z;
        if (_bossStats.IsActualDashActive && Vector3.Distance(animator.transform.position, _playerPosition) >= 1.75f)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, _playerPosition, _bossStats.DashMovementSpeed * Time.deltaTime);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("dash");
    }
}
