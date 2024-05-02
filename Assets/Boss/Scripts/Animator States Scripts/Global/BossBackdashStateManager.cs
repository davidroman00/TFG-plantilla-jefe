using UnityEngine;

public class BossBackdashStateManager : StateMachineBehaviour
{
    BossStats _bossStats;
    BossReferences _bossReferences;
    Vector3 _playerPosition;
    Vector3 _bossPosition;
    Vector3 _moveDirection;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossStats = animator.GetComponent<BossStats>();
        _bossReferences = animator.GetComponent<BossReferences>();
        animator.GetComponent<BossCooldownManager>().LastBackdash = Time.time;

        //We only need the Z axis for this movement.
        _playerPosition.z = _bossReferences.PlayerTransform.position.z;
        _playerPosition.z = -_playerPosition.z;
        _bossPosition.z = animator.transform.position.z;

        //This line here is calculating the direction vector to be applied.
        _moveDirection = _playerPosition - _bossPosition;

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_bossStats.IsActualBackdashActive && !_bossStats.IsOutsideArena)
        //Since the boss is moved through transform.position, it is important to check if the boss is within the arena during the movement, otherwise it could clip thorugh walls.
        {
            animator.transform.Translate(_bossStats.DashMovementSpeed * Time.deltaTime * _moveDirection.normalized);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("backdash");
    }
}
