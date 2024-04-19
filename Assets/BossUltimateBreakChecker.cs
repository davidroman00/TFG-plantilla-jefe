using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUltimateBreakChecker : StateMachineBehaviour
{
    UltimateDeviceManager _ultimateDevice;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ultimateDevice = FindAnyObjectByType<UltimateDeviceManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_ultimateDevice)
        {
            animator.SetTrigger("ultimateBreak");
        }
    }
}
