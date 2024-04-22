using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAnimationManager : StateMachineBehaviour
{
    EnemyHealthManager _enemyHealthManager;
    BossStatsPhase2 _bossStats;
    BossReferencesPhase2 _bossReferences;
    BossCooldownManagerPhase2 _bossCooldownManager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyHealthManager = animator.GetComponent<EnemyHealthManager>();
        _bossStats = animator.GetComponent<BossStatsPhase2>();
        _bossReferences = animator.GetComponent<BossReferencesPhase2>();
        _bossCooldownManager = animator.GetComponent<BossCooldownManagerPhase2>();
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
        if (_bossCooldownManager.IsPatternMeleeOnCooldown() && _bossCooldownManager.IsSimpleMeleeOnCooldown())
        {
            animator.SetBool("anyMeleeReady", false);
        }
        animator.ResetTrigger("meleePattern");
        animator.ResetTrigger("meleeSimple");
        animator.ResetTrigger("dash");
    }
    void PhaseChangeChecker(Animator animator)
    {
        if (_enemyHealthManager.CurrentHealth <= 0)
        {
            animator.SetTrigger("phaseChange");
        }
    }
    void PatternMeleeChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) <= _bossStats.MeleeMaxDistance) && !_bossCooldownManager.IsPatternMeleeOnCooldown())
        {
            animator.SetTrigger("meleePattern");
            _bossCooldownManager.LastPatternMelee = Time.time;
        }
    }
    void SimpleMeleeChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) <= _bossStats.MeleeMaxDistance) && !_bossCooldownManager.IsSimpleMeleeOnCooldown())
        {
            animator.SetTrigger("meleeSimple");
            _bossCooldownManager.LastSimpleMelee = Time.time;

        }
    }
    void SimpleDashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.DashMinDistance) && !_bossCooldownManager.IsSimpleDashOnCooldown())
        {
            animator.SetTrigger("dash");
            _bossCooldownManager.LastSimpleDash = Time.time;
        }
    }
}
