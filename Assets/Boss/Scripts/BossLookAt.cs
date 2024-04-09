using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : StateMachineBehaviour
{
    Transform _playerTransform;
    Vector3 _playerPosition;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerTransform = animator.GetComponent<BossReferences>().PlayerTransform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerPosition.x = _playerTransform.position.x;
        _playerPosition.z = _playerTransform.position.z;
        animator.transform.LookAt(_playerPosition);
    }

}
