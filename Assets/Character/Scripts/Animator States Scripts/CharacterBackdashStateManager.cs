using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBackdashStateManager : StateMachineBehaviour
{
    CharacterStats _characterStats;
    CharacterMovementAndAnimationsController _characterMovementAndAnimationsController;
    CharacterController _characterController;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterMovementAndAnimationsController = animator.GetComponent<CharacterMovementAndAnimationsController>();
        _characterController = animator.GetComponent<CharacterController>();
        _characterStats = animator.GetComponent<CharacterStats>();
        _characterMovementAndAnimationsController.IsBackdashing = true; //This line here is necessary to avoid the character moving while the animation lasts.
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_characterMovementAndAnimationsController.IsActualBackdashActive)
        {
            _characterController.Move(_characterStats.BackdashMovementSpeed * Time.deltaTime * _characterMovementAndAnimationsController.BackdashMoveDirection.normalized);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("backdash");
        _characterMovementAndAnimationsController.IsBackdashing = false;
    }
}
