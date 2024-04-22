using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAnimationManager : StateMachineBehaviour
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
