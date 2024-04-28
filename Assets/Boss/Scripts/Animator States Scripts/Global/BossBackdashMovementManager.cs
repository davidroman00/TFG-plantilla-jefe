using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBackdashMovementManager : StateMachineBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    Vector3 _playerPosition;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerPosition.x = _bossReferences.PlayerTransform.position.x;
        _playerPosition.z = _bossReferences.PlayerTransform.position.z;
        _playerPosition.x = -_playerPosition.x;
        _playerPosition.z = -_playerPosition.z;
        if (_bossReferences.IsActualBackdashActive)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, _playerPosition, _bossStats.DashMovementSpeed * Time.deltaTime);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("backdash");
    }
}
