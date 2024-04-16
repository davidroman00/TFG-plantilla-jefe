using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationManager : StateMachineBehaviour
{
    EnemyHealthManager _enemyHealthManager;
    BossStats _bossStats;
    BossReferences _bossReferences;
    BossCooldownManager _bossCooldownManager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyHealthManager = animator.GetComponent<EnemyHealthManager>();
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
        _bossCooldownManager = animator.GetComponent<BossCooldownManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PhaseChangeChecker(animator);
        PatternRangedChecker(animator);
        ZigZagDashChecker(animator);
        AnyMeleeReadyChecker(animator);
        SimpleDashChecker(animator);
        SimpleRangedChecker(animator);
        AreaChecker(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("rangedPattern");
        animator.ResetTrigger("rangedSimple");
        animator.ResetTrigger("dashZigZag");
        animator.ResetTrigger("dash");
        animator.ResetTrigger("area");
        animator.ResetTrigger("phaseChange");
    }
    void PhaseChangeChecker(Animator animator)
    {
        if (_enemyHealthManager.CurrentHealth <= 0)
        {
            animator.SetTrigger("phaseChange");
        }
    }
    void PatternRangedChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) > _bossStats.RangedMinDistance) && !_bossCooldownManager.IsPatternRangedOnCooldown())
        {
            animator.SetTrigger("rangedPattern");
        }
    }
    void SimpleRangedChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) > _bossStats.RangedMinDistance) && !_bossCooldownManager.IsSimpleMeleeOnCooldown())
        {
            animator.SetTrigger("rangedSimple");
        }
    }
    void ZigZagDashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) > _bossStats.DashMinDistance) && !_bossCooldownManager.IsZigZagDashOnCooldown())
        {
            animator.SetTrigger("dashZigZag");
        }
    }
    void SimpleDashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) > _bossStats.DashMinDistance) && !_bossCooldownManager.IsSimpleDashOnCooldown())
        {
            animator.SetTrigger("dash");
        }
    }
    void AreaChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsAreaOnCooldown())
        {
            animator.SetTrigger("area");
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
