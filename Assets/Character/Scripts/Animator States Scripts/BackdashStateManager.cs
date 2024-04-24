using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdashStateManager : StateMachineBehaviour
{
    CharacterStats _characterStats;
    CharacterMovementAndAnimationsController _characterMovementAndAnimationsController;
    CharacterController _characterController;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterMovementAndAnimationsController = animator.GetComponent<CharacterMovementAndAnimationsController>();
        _characterController = animator.GetComponent<CharacterController>();
        _characterStats = animator.GetComponent<CharacterStats>();
        _characterMovementAndAnimationsController.IsBackdashing = true; //para evitar que el pj se mueva durante la animacion
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_characterMovementAndAnimationsController.IsActualBackdashActive)
        {
            _characterController.Move(_characterMovementAndAnimationsController.BackdashMoveDirection.normalized * Time.deltaTime * _characterStats.BackdashMovementSpeed);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("backdashed");
        _characterMovementAndAnimationsController.IsBackdashing = false;
    }
}
