using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackStateManager : StateMachineBehaviour
{   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CharacterMovementAndAnimationsController>().IsAttacking = true; //This line here is necessary to avoid the character moving while the animation lasts.
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attacked");
        animator.GetComponent<CharacterMovementAndAnimationsController>().IsAttacking = false;
        animator.GetComponentInChildren<CharacterMeleeWeapon>().enabled = false;
    }
}
