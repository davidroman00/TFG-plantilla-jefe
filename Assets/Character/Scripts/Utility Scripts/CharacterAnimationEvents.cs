using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    WeaponDamageManager _weaponDamageManager;
    CharacterMovementAndAnimationsController _characterMovementAndAnimationsController;
    void Awake()
    {
        _weaponDamageManager = GetComponentInChildren<WeaponDamageManager>();
        _characterMovementAndAnimationsController = GetComponent<CharacterMovementAndAnimationsController>();
    }
    public void OnAttackStart()
    {
        _weaponDamageManager.enabled = true;
    }
    public void OnAttackMid()
    {
        _weaponDamageManager.enabled = false;
    }
    public void ActualBackdashStart()
    {
        _characterMovementAndAnimationsController.IsActualBackdashActive = true;
    }
    public void ActualBackdashEnd()
    {
        _characterMovementAndAnimationsController.IsActualBackdashActive = false;
    }
}
