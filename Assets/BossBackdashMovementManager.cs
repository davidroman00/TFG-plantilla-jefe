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
        if (_bossReferences.IsActualBackdashActive)
        {
            _playerPosition.x = _bossReferences.PlayerTransform.position.x;
            _playerPosition.z = _bossReferences.PlayerTransform.position.z;

            animator.transform.position = - Vector3.MoveTowards(animator.transform.position, _playerPosition, _bossStats.DashMovementSpeed * Time.deltaTime);
            Debug.Log(animator.transform.position);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("backdash");
    }
}
