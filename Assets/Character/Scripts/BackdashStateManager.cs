using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdashStateManager : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CharacterMovementAndAnimationsController>().IsBackdashing = true; //para evitar que el pj se mueva durante la animacion
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Backdashed");
        animator.GetComponent<CharacterMovementAndAnimationsController>().IsBackdashing = false;
    }
}
