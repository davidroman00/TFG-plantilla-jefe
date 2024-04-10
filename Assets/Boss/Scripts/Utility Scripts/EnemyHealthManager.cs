using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{ //podria ser el mismo script de recibir daño en el pj y el boss, pero de esta manera se evita el friendly fire, entre otras cosas
    float _currentHealth;
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = GetComponent<BossStats>();
        _currentHealth = _bossStats.BossMaxHP;
    }

    public void CurrentHealthManager(float value)
    {
        _currentHealth -= value;
    }
}
