using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    float _maxHealth = 100f;
    [SerializeField]
    float _movementSpeed = 10f;
    [SerializeField]
    float _attackDamage = 10f;
    [SerializeField]
    float _attackCooldown = 1f;
    [SerializeField]
    float _backdashCooldown = 2.5f;

    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public float MovementSpeed { get { return _movementSpeed; } }
    public float AttackDamage { get { return _attackDamage; } }
    public float AttackCooldown { get { return _attackCooldown; } }
    public float BackdashCooldown { get { return _backdashCooldown; } }
}
