using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int _speed = 10;
    Animator _animator;
    CharacterController _characterController;
    PlayerControlls _playerControlls;
    Vector2 _movementInput;
    Vector3 _movementApplied;
    bool _isMoving;
    bool _isAttackPressed;
    bool _isBackdashPressed;
    float _rotationFactor = 10;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        
        _playerControlls = new PlayerControlls();
        _playerControlls.Default.Movement.started += OnMovementPressed;
        _playerControlls.Default.Movement.canceled += OnMovementPressed;
        _playerControlls.Default.Attack.started += OnAttackPressed;
        _playerControlls.Default.Attack.canceled += OnAttackPressed;
        _playerControlls.Default.Backdash.started += OnBackdashPressed;
        _playerControlls.Default.Backdash.canceled += OnBackdashPressed;
    }
    void Update()
    {
        AnimatorController();
        ApplyMovementToPlayer();
        HandleRotation();
    }

    void AnimatorController()
    {
        if (_isMoving)
        {
            _animator.SetBool("isWalking", true);
        }
        else if (!_isMoving)
        {
            _animator.SetBool("isWalking", false);
        }
        if (_isBackdashPressed)
        {
            _animator.SetTrigger("Backdashed");
        }
        if (_isAttackPressed)
        {
            _animator.SetTrigger("Attacked");
        }
    }
    void HandleRotation()
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = _movementApplied.x;
        positionToLookAt.y = 0;
        positionToLookAt.z = _movementApplied.z;
        Quaternion currentRotation = transform.rotation;
        if (_isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactor * Time.deltaTime);
        }
    }
    void ApplyMovementToPlayer()
    {
        _characterController.Move(_movementApplied * Time.deltaTime * _speed);
    }    
    void OnMovementPressed(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        _movementApplied.x = _movementInput.x;
        _movementApplied.z = _movementInput.y;
        _isMoving = _movementApplied.x != 0 || _movementApplied.z != 0;
    }
    void OnAttackPressed(InputAction.CallbackContext context)
    {
        _isAttackPressed = context.ReadValueAsButton();
    }
    void OnBackdashPressed(InputAction.CallbackContext context)
    {
        _isBackdashPressed = context.ReadValueAsButton();
    }
    void OnEnable()
    {
        _playerControlls.Default.Enable();
    }
    void OnDisable()
    {
        _playerControlls.Default.Disable();
    }
}
