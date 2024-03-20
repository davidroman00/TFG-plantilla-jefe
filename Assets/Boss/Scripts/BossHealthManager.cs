using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    float _currentHealth = 100;
    //BossStats _bossStats;
    void Awake()
    {
        //_bossStats = GetComponent<BossStats>();
        //_currentHealth = _bossStats.MaxHealth;
    }

    public void CurrentHealthManager(float value){
        _currentHealth -= value;    
        Debug.Log(_currentHealth);
    }
}
