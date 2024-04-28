using System.Collections;
using System.Collections.Generic;
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
