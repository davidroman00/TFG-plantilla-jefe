using UnityEngine;

public class BossMeleeAnimationManager : StateMachineBehaviour
{
    //This script handles the movements available while the boss walks towards the character.
    BossHealthManager _bossHealthManager;
    BossStats _bossStats;
    BossReferences _bossReferences;
    BossCooldownManager _bossCooldownManager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossHealthManager = animator.GetComponentInChildren<BossHealthManager>();
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
        _bossCooldownManager = animator.GetComponent<BossCooldownManager>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PhaseChangeChecker(animator);
        PatternMeleeChecker(animator);
        SimpleMeleeChecker(animator);
        SimpleDashChecker(animator);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("meleeSimple");
        animator.ResetTrigger("meleePattern");
        animator.ResetTrigger("dash");
        //Resetting triggers at the exit of this state is important, so triggers don't stack in the animator while waiting for the current animation to end.
        //It only happens if two, or more, of them are set at the same time.
    }
    //The conditions behind every movement to trigger.
    void PhaseChangeChecker(Animator animator)
    {
        if (_bossHealthManager.CurrentHealth <= 0)
        {
            animator.SetTrigger("phaseChange");
        }
    }
    void PatternMeleeChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) <= _bossStats.MeleeMaxDistance) && !_bossCooldownManager.IsPatternMeleeOnCooldown())
        {
            animator.SetTrigger("meleePattern");
        }
    }
    void SimpleMeleeChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) <= _bossStats.MeleeMaxDistance) && !_bossCooldownManager.IsSimpleMeleeOnCooldown())
        {
            animator.SetTrigger("meleeSimple");
        }
    }
    void SimpleDashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.DashMinDistance) && !_bossCooldownManager.IsSimpleDashOnCooldown())
        {
            animator.SetTrigger("dash");
        }
    }
}