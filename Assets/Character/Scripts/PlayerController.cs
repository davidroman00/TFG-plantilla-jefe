using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int _speed = 10;
    CharacterController _characterController;
    PlayerControlls _playerControlls;
    Vector2 _movementInput;
    Vector3 _movementApplied;
    bool _isMoving;
    bool _isAttackPressed;
    bool _isBackdashPressed;


    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerControlls = new PlayerControlls();
        _playerControlls.Default.Movement.started += onMovementInput;
        _playerControlls.Default.Movement.canceled += onMovementInput;
    }
    void Update()
    {
        _characterController.Move(_movementApplied * Time.deltaTime * _speed);
        Debug.Log(_isMoving);
    }

    void onMovementInput(InputAction.CallbackContext context){
        _movementInput = context.ReadValue<Vector2>();
        _movementApplied.x = _movementInput.x;
        _movementApplied.z = _movementInput.y;
        _isMoving = _movementApplied.x != 0 || _movementApplied.z != 0;
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
