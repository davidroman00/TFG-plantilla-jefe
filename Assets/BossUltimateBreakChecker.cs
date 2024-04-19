using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUltimateBreakChecker : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (FindAnyObjectByType<UltimateDeviceManager>() && FindAnyObjectByType<UltimateDeviceManager>().IsDeviceDestroyed)
        {
            animator.SetTrigger("ultimateBreak");
        }
    }
}
