using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleAnimationsManagerPhase2 : StateMachineBehaviour
{
    EnemyHealthManager _enemyHealthManager;
    BossStats _bossStats;
    BossReferences _bossReferences;
    BossCooldownManager _bossCooldownManager;
    int _bossActualUltimateUses;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyHealthManager = animator.GetComponent<EnemyHealthManager>();
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
        _bossCooldownManager = animator.GetComponent<BossCooldownManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PatternRangedChecker(animator);
        SimpleRangedChecker(animator);
        AnyMeleeReadyChecker(animator);
        SimpleDashChecker(animator);
        BackDashChecker(animator);
        AreaChecker(animator);
        UltimateChecker(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("rangedPattern");
        animator.ResetTrigger("rangedSimple");
        animator.ResetTrigger("dash");
        animator.ResetTrigger("backdash");
        animator.ResetTrigger("area");
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
    void UltimateChecker(Animator animator)
    {
        if (_bossActualUltimateUses < _bossStats.BossMaxUltimateUses && _enemyHealthManager.CurrentHealth <= _bossStats.BossUltimateHPThreshold)
        {
            animator.SetBool("walkingToUltimate", true);
            _bossActualUltimateUses++;
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
