using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{ //podria ser el mismo script de recibir daño en el pj y el boss, pero de esta manera se evita el friendly fire
    float _currentHealth = 100;
    //BossStats _bossStats;
    void Awake()
    {
        //_bossStats = GetComponent<BossStats>();
        //_currentHealth = _bossStats.MaxHealth;
    }

    public void CurrentHealthManager(float value)
    {
        _currentHealth -= value;
        Debug.Log(_currentHealth);
    }
}
