using UnityEngine;

public class BossRangedPatternStateManager : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossCooldownManager>().LastPatternRanged = Time.time;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("rangedPattern");
    }
}
