using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkToPlayer : StateMachineBehaviour
{
    BossStatsPhase2 _bossStats;
    Transform _playerTransform;
    Vector3 _playerPosition;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStatsPhase2>();
        _playerTransform = animator.GetComponent<BossReferencesPhase2>().PlayerTransform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerPosition.x = _playerTransform.position.x;
        _playerPosition.z = _playerTransform.position.z;
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, _playerPosition, _bossStats.BossMovementSpeed * Time.deltaTime);
    }
}
