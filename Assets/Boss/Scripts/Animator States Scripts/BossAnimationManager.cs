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
        //PhaseChangeChecker(animator);
        //PatternRangedChecker(animator);
        SimpleRangedChecker(animator);
        //AnyMeleeReadyChecker(animator);
        //ZigZagDashChecker(animator);
        //SimpleDashChecker(animator);
        //BackDashChecker(animator);
        //AreaChecker(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("rangedPattern");
        animator.ResetTrigger("rangedSimple");
        animator.ResetTrigger("dashZigZag");
        animator.ResetTrigger("dash");
        animator.ResetTrigger("backdash");
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
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.RangedMinDistance) && _bossCooldownManager.IsPatternRangedOnCooldown() == false)
        {
            animator.SetTrigger("rangedPattern");
            _bossCooldownManager.LastPatternRanged = Time.time;
        }
    }
    void SimpleRangedChecker(Animator animator)
    {
        Debug.Log("Is ditance enough? " + (Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.RangedMinDistance));
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.RangedMinDistance) && _bossCooldownManager.IsSimpleMeleeOnCooldown() == false)
        {
            animator.SetTrigger("rangedSimple");
            _bossCooldownManager.LastSimpleRanged = Time.time;
        }
    }
    void ZigZagDashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.DashMinDistance) && _bossCooldownManager.IsZigZagDashOnCooldown() == false)
        {
            animator.SetTrigger("dashZigZag");
            _bossCooldownManager.LastZigZagDash = Time.time;
        }
    }
    void SimpleDashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) >= _bossStats.DashMinDistance) && _bossCooldownManager.IsSimpleDashOnCooldown() == false)
        {
            animator.SetTrigger("dash");
            _bossCooldownManager.LastSimpleDash = Time.time;
        }
    }
    void BackDashChecker(Animator animator)
    {
        if ((Vector3.Distance(_bossReferences.PlayerTransform.position, animator.transform.position) <= _bossStats.DashMaxDistance) && _bossCooldownManager.IsBackDashOnCooldown() == false)
        {
            animator.SetTrigger("backdash");
            _bossCooldownManager.LastBackDash = Time.time;    
        }
    }
    void AreaChecker(Animator animator)
    {
        if (_bossCooldownManager.IsAreaOnCooldown() == false)
        {
            animator.SetTrigger("area");
            _bossCooldownManager.LastArea = Time.time;
        }
    }
    void AnyMeleeReadyChecker(Animator animator)
    {
        if (_bossCooldownManager.IsSimpleMeleeOnCooldown() == false || _bossCooldownManager.IsPatternMeleeOnCooldown() == false)
        {
            animator.SetBool("anyMeleeReady", true);
        }
    }
}
