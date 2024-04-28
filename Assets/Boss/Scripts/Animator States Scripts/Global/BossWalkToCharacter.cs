using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkToCharacter : StateMachineBehaviour
{
    //Use it if you need the boss to walk towards the character.
    BossStats _bossStats;
    Transform _playerTransform;
    Vector3 _playerPosition;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _playerTransform = animator.GetComponent<BossReferences>().PlayerTransform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerPosition.x = _playerTransform.position.x;
        _playerPosition.z = _playerTransform.position.z;
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, _playerPosition, _bossStats.BossMovementSpeed * Time.deltaTime);
    }
}
