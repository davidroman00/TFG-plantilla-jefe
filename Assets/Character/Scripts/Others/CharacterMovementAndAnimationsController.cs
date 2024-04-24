using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovementAndAnimationsController : MonoBehaviour
{
    //variables necesarias para manejar cds y demás
    bool _isAttacking;
    public bool IsAttacking { set { _isAttacking = value; } }
    bool _isBackdashing;
    public bool IsBackdashing { set { _isBackdashing = value; } }
    bool _isActualBackdashActive;
    public bool IsActualBackdashActive { get { return _isActualBackdashActive; } set { _isActualBackdashActive = value; } }
    float _lastAttackUse;
    float _lastBackdashUse;
    [SerializeField]
    Image _backdashImage;
    [SerializeField]
    Image _attackImage;
    CharacterStats _characterStats;

    //variables necesarias para el movimiento y las animaciones
    float _turnSmoothTime = .05f;
    float _turnSmoothVelocity;
    float _horizontalInput;
    float _verticalInput;
    Vector3 _initialDirection;
    Vector3 _moveDirection;
    Vector3 _backdashMoveDirection;
    public Vector3 BackdashMoveDirection { get { return _backdashMoveDirection; } } 
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
        ShowSkillsCooldownInUI();
    }

    void HandleInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _initialDirection = new Vector3(_horizontalInput, 0f, _verticalInput).normalized;

        if (_initialDirection.magnitude > .05f && !_isAttacking && !_isBackdashing)
        {
            HandlePlayerMovementAndRotation();
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown("space") && !IsBackdashOnCooldown())
        {
            _animator.SetTrigger("backdashed");
            _lastBackdashUse = Time.time;
        }
        if (Input.GetMouseButtonDown(0) && !IsAttackOnCooldown())
        {
            _animator.SetTrigger("attacked");
            _lastAttackUse = Time.time;
        }
    }
    void HandlePlayerMovementAndRotation()
    {
        float targetAngle = Mathf.Atan2(_initialDirection.x, _initialDirection.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        _moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        _backdashMoveDirection = -_moveDirection;
        _characterController.Move(_moveDirection.normalized * _characterStats.MovementSpeed * Time.deltaTime);
    }
    void ShowSkillsCooldownInUI()
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
            _attackImage.fillAmount = (Time.time - _lastAttackUse)  / _characterStats.AttackCooldown;
        }
        else if (!IsAttackOnCooldown())
        {
            _attackImage.fillAmount = 0;
        }
    }
    bool IsBackdashOnCooldown()
    {
        return Time.time < _lastBackdashUse + _characterStats.BackdashCooldown;
    }
    bool IsAttackOnCooldown()
    {
        return Time.time < _lastAttackUse + _characterStats.AttackCooldown;
    }
}
