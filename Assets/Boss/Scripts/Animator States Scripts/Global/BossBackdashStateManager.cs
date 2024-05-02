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

        _playerPosition.x = _bossReferences.PlayerTransform.position.x;
        _playerPosition.z = _bossReferences.PlayerTransform.position.z;
        _playerPosition.x = -_playerPosition.x;
        _playerPosition.z = -_playerPosition.z;
        
        _bossPosition.x = animator.transform.position.x;
        _bossPosition.z = animator.transform.position.z;

        //This line here is calculating the direction vector to be applied.
        _moveDirection = _playerPosition - _bossPosition;        
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {     
        if (_bossStats.IsActualBackdashActive && !_bossStats.IsOutsideArena)
        {
            Debug.Log(_bossStats.IsOutsideArena);
            animator.transform.Translate(_bossStats.DashMovementSpeed * Time.deltaTime * _moveDirection.normalized);
        }        
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("backdash");
        _playerPosition = Vector3.zero;
        _bossPosition = Vector3.zero;
        _moveDirection = Vector3.zero;
    }
}
