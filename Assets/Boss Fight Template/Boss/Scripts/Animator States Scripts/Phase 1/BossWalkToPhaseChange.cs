using UnityEngine;

public class BossWalkToPhaseChange : StateMachineBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.position != _bossReferences.ArenaCenter.position)
        {
            BossWalkToPosition(animator);
        }
        else
        {
            animator.SetBool("walkingToPhaseChange", false);
            animator.SetTrigger("inPositionToPhaseChange");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(Vector3.back);
    }
    void BossWalkToPosition(Animator animator)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, _bossReferences.ArenaCenter.position, _bossStats.BossMovementSpeed * Time.deltaTime);
        animator.transform.LookAt(_bossReferences.ArenaCenter.position);
    }
}
