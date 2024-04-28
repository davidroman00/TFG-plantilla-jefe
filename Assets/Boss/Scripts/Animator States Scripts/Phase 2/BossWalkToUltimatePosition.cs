using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkToUltimatePosition : StateMachineBehaviour
{
    BossReferences _bossReferences;
    BossStats _bossStats;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossReferences = animator.GetComponent<BossReferences>();
        _bossStats = animator.GetComponent<BossStats>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.position != _bossReferences.UltimateBossPosition.position)
        {
            BossWalkToPosition(animator);
        }
        else
        {
            animator.SetBool("walkingToUltimate", false);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(_bossReferences.UltimateDevicePrefab, _bossReferences.UltimateDeviceSpawnPoint);
        animator.transform.LookAt(Vector3.back);
        animator.GetComponent<BossCooldownManager>().LastUltimate = Time.time;
    }
    void BossWalkToPosition(Animator animator)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, _bossReferences.UltimateBossPosition.position, _bossStats.BossMovementSpeed * Time.deltaTime);
        animator.transform.LookAt(_bossReferences.UltimateBossPosition.position);
    }
}
