using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
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


    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public float MovementSpeed { get { return _movementSpeed; } }
    public float BackdashMovementSpeed { get { return _backdashMovementSpeed; } }
    public float AttackDamage { get { return _attackDamage; } }
    public float AttackCooldown { get { return _attackCooldown; } }
    public float BackdashCooldown { get { return _backdashCooldown; } }
}
