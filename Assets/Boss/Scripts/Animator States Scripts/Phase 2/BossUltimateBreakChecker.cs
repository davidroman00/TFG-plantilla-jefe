using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUltimateBreakChecker : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (FindAnyObjectByType<UltimateDeviceManager>() && FindAnyObjectByType<UltimateDeviceManager>().IsDeviceDestroyed)
        //This double-checking is necessary so, during the first frames, you don't get a NullReferenceException; since Unity needs some time to locate the object.
        {
            animator.SetTrigger("ultimateBreak");
        }
    }
}
