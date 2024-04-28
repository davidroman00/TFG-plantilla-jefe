using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovementAndAnimationsController : MonoBehaviour
{
    //This is the core script of the character.

    //Necessary variables to handle Cooldowns.
    float _lastAttackUse;
    float _lastBackdashUse;
    [SerializeField]
    Image _backdashImage;
    [SerializeField]
    Image _attackImage;
    CharacterStats _characterStats;

    //Necessary variables to handle movement, rotation and animations.
    float _turnSmoothTime = .075f;
    float _turnSmoothVelocity;
    float _targetAngle;
    float _appliedAngle;
    float _horizontalInput;
    float _verticalInput;
    Vector3 _initialDirection;
    Vector3 _moveDirection;
    Vector3 _backdashMoveDirection;
    public Vector3 BackdashMoveDirection { get { return _backdashMoveDirection; } }
    bool _isAttacking;
    public bool IsAttacking { set { _isAttacking = value; } }
    bool _isBackdashing;
    public bool IsBackdashing { set { _isBackdashing = value; } }
    bool _isActualBackdashActive;
    public bool IsActualBackdashActive { get { return _isActualBackdashActive; } set { _isActualBackdashActive = value; } }
    CharacterController _characterController;
    [SerializeField]
    Transform _camera;
    Animator _animator;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _characterStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        HandleInput();
        ShowSkillsCooldownOnScreen();
    }

    void HandleInput()
    {
        //Storing movement input.
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _initialDirection = new Vector3(_horizontalInput, 0f, _verticalInput).normalized;

        //Handling animations, cooldowns and other inputs.
        if (_initialDirection.magnitude > .05f && !_isAttacking && !_isBackdashing)
        {
            HandlePlayerMovementAndRotation();
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !IsBackdashOnCooldown())
        {
            _animator.SetTrigger("backdash");
            _lastBackdashUse = Time.time;
        }
        if (Input.GetMouseButtonDown(0) && !IsAttackOnCooldown())
        {
            _animator.SetTrigger("attack");
            _lastAttackUse = Time.time;
        }
    }
    void HandlePlayerMovementAndRotation()
    {
        //Handling character rotation.
        _targetAngle = Mathf.Atan2(_initialDirection.x, _initialDirection.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
        _appliedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, _appliedAngle, 0);

        //Handling character movement.
        _moveDirection = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;
        _characterController.Move(_characterStats.MovementSpeed * Time.deltaTime * _moveDirection.normalized);

        _backdashMoveDirection = Quaternion.Euler(0, _appliedAngle, 0) * Vector3.back;
    }
    //Handling cooldowns on screen.
    void ShowSkillsCooldownOnScreen()
    {
        if (IsBackdashOnCooldown())
        {
            _backdashImage.fillAmount = (Time.time - _lastBackdashUse) / _characterStats.BackdashCooldown;
        }
        else if (!IsBackdashOnCooldown())
        {
            _backdashImage.fillAmount = 0;
        }
        if (IsAttackOnCooldown())
        {
            _attackImage.fillAmount = (Time.time - _lastAttackUse) / _characterStats.AttackCooldown;
        }
        else if (!IsAttackOnCooldown())
        {
            _attackImage.fillAmount = 0;
        }
    }
    //Handling cooldowns.
    bool IsBackdashOnCooldown()
    {
        return Time.time < _lastBackdashUse + _characterStats.BackdashCooldown;
    }
    bool IsAttackOnCooldown()
    {
        return Time.time < _lastAttackUse + _characterStats.AttackCooldown;
    }
}
