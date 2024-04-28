using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRangedSimpleStateManager : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossCooldownManager>().LastSimpleRanged = Time.time;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("rangedSimple");
    }
}