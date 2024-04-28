using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //Here, there are stored every variable relative to the character statistics.
    [SerializeField]
    float _maxHealth;
    [SerializeField]
    float _movementSpeed;
    [SerializeField]
    float _backdashMovementSpeed;
    [SerializeField]
    float _attackDamage;
    [SerializeField]
    float _attackCooldown;
    [SerializeField]
    float _backdashCooldown;

    //This section is in charge of exporting every variable in ReadOnly, thanks to the getter.
    //If you wan to modify this variables dynamically, you need a setter instead.
    public float MaxHealth { get { return _maxHealth; } }
    public float MovementSpeed { get { return _movementSpeed; } }
    public float BackdashMovementSpeed { get { return _backdashMovementSpeed; } }
    public float AttackDamage { get { return _attackDamage; } }
    public float AttackCooldown { get { return _attackCooldown; } }
    public float BackdashCooldown { get { return _backdashCooldown; } }
}
