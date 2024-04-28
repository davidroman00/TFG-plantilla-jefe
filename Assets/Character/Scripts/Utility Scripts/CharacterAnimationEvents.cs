using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    CharacterMeleeWeapon _characterMeleeWeapon;
    CharacterMovementAndAnimationsController _characterMovementAndAnimationsController;
    void Awake()
    {
        _characterMeleeWeapon = GetComponentInChildren<CharacterMeleeWeapon>();
        _characterMovementAndAnimationsController = GetComponent<CharacterMovementAndAnimationsController>();
    }
    //These are public methods so they can be accessed through an animation event
    public void OnAttackStart()
    {
        _characterMeleeWeapon.enabled = true;
    }
    public void OnAttackMid()
    {
        _characterMeleeWeapon.enabled = false;
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
