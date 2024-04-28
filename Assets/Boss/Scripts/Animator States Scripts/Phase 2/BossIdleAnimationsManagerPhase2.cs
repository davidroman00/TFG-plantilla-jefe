using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleAnimationsManagerPhase2 : StateMachineBehaviour
{
    BossHealthManager _bossHealthManager;
    BossStats _bossStats;
    BossReferences _bossReferences;
    BossCooldownManager _bossCooldownManager;
    int _bossActualUltimateUses;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossHealthManager = animator.GetComponentInChildren<BossHealthManager>();
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
        _bossCooldownManager = animator.GetComponent<BossCooldownManager>();
        animator.ResetTrigger("rangedPatternEnd");
        animator.ResetTrigger("areaEnd");
        animator.ResetTrigger("ultimateBreakEnd");
        animator.ResetTrigger("ultimateBreak");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PatternRangedChecker(animator);
        SimpleRangedChecker(animator);
        AnyMeleeReadyChecker(animator);
        SimpleDashChecker(animator);
        BackdashChecker(animator);
        AreaChecker(animator);
        UltimateChecker(animator);
    }
    void PatternRangedChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.RangedMinDistance) && !_bossCooldownManager.IsPatternRangedOnCooldown())
        {
            animator.SetTrigger("rangedPattern");
        }
    }
    void SimpleRangedChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.RangedMinDistance) && !_bossCooldownManager.IsSimpleRangedOnCooldown())
        {
            animator.SetTrigger("rangedSimple");
        }
    }
    void SimpleDashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.DashMinDistance) && !_bossCooldownManager.IsSimpleDashOnCooldown())
        {
            animator.SetTrigger("dash");
        }
    }
    void BackdashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) <= _bossStats.DashMaxDistance) && !_bossCooldownManager.IsBackDashOnCooldown())
        {
            animator.SetTrigger("backdash");
        }
    }
    void AreaChecker(Animator animator)
    {
        if (!_bossCooldownManager.IsAreaOnCooldown())
        {
            animator.SetTrigger("area");
        }
    }
    void UltimateChecker(Animator animator)
    {
        if (_bossActualUltimateUses < _bossStats.BossMaxUltimateUses && _bossHealthManager.CurrentHealth <= _bossStats.BossUltimateHPThreshold && !_bossCooldownManager.IsUltimateOnCooldown())
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
