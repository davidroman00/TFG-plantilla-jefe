using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementAndAnimationsController : MonoBehaviour
{
    float _lastAttackUse;
    float _lastBackdashUse;
    float _turnSmoothTime = .1f;
    float _turnSmoothVelocity;
    float _horizontalInput;
    float _verticalInput;
    Vector3 _initialDirection;
    Vector3 _moveDirection;
    [SerializeField]
    Transform _camera;
    Animator _animator;
    CharacterController _characterController;
    CharacterStats _characterStats;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _characterStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        HandleInput();  

        if (_initialDirection.magnitude > .1f){
            HandlePlayerMovementAndRotation();
            _animator.SetBool("isWalking", true);            
        } else {
            _animator.SetBool("isWalking", false);
        } 
    }

    void HandleInput(){
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _initialDirection = new Vector3 (_horizontalInput, 0f, _verticalInput).normalized;

        if(Input.GetKeyDown("space") && !IsBackdashOnCooldown()){
            _animator.SetTrigger("Backdashed");
            _lastBackdashUse = Time.time;
        } 
        if(Input.GetMouseButtonDown(0) && !IsAttackOnCooldown()){
            _animator.SetTrigger("Attacked");
            _lastAttackUse = Time.time;
        } 

    }
    void HandlePlayerMovementAndRotation(){
        float targetAngle = Mathf.Atan2(_initialDirection.x, _initialDirection.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        _moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        _characterController.Move(_moveDirection.normalized * _characterStats.MovementSpeed * Time.deltaTime);
    }
    bool IsBackdashOnCooldown(){
        return Time.time < _lastBackdashUse + _characterStats.BackdashCooldown;
    }
    bool IsAttackOnCooldown(){
        return Time.time < _lastAttackUse + _characterStats.AttackCooldown;
    }
}
