using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleAnimationManagerPhase1 : StateMachineBehaviour
{
    EnemyHealthManager _enemyHealthManager;
    BossStatsPhase1 _bossStats;
    BossReferencesPhase1 _bossReferences;
    BossCooldownManagerPhase1 _bossCooldownManager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyHealthManager = animator.GetComponent<EnemyHealthManager>();
        _bossStats = animator.GetComponent<BossStatsPhase1>();
        _bossReferences = animator.GetComponent<BossReferencesPhase1>();
        _bossCooldownManager = animator.GetComponent<BossCooldownManagerPhase1>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PhaseChangeChecker(animator);
        PatternRangedChecker(animator);
        SimpleRangedChecker(animator);
        AnyMeleeReadyChecker(animator);
        SimpleDashChecker(animator);
        BackDashChecker(animator);
        AreaChecker(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("rangedPattern");
        animator.ResetTrigger("rangedSimple");
        animator.ResetTrigger("dash");
        animator.ResetTrigger("backdash");
        animator.ResetTrigger("area");
    }
    void PhaseChangeChecker(Animator animator)
    {
        if (_enemyHealthManager.CurrentHealth <= 0)
        {
            animator.SetBool("walkingToPhaseChange", true);
        }
    }
    void PatternRangedChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.RangedMinDistance) && !_bossCooldownManager.IsPatternRangedOnCooldown())
        {
            animator.SetTrigger("rangedPattern");
            _bossCooldownManager.LastPatternRanged = Time.time;
        }
    }
    void SimpleRangedChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.RangedMinDistance) && !_bossCooldownManager.IsSimpleRangedOnCooldown())
        {
            animator.SetTrigger("rangedSimple");
            _bossCooldownManager.LastSimpleRanged = Time.time;
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
    void BackDashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) <= _bossStats.DashMaxDistance) && !_bossCooldownManager.IsBackDashOnCooldown())
        {
            animator.SetTrigger("backdash");
            _bossCooldownManager.LastBackDash = Time.time;
        }
    }
    void AreaChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsAreaOnCooldown())
        {
            animator.SetTrigger("area");
            _bossCooldownManager.LastArea = Time.time;
        }
    }
    void AnyMeleeReadyChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsSimpleMeleeOnCooldown() || !_bossCooldownManager.IsPatternMeleeOnCooldown())
        {
            animator.SetBool("anyMeleeReady", true);
        }
    }
}
