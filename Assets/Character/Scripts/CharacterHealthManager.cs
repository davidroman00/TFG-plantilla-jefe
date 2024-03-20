using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthManager : MonoBehaviour
{
    float _currentHealth;
    CharacterStats _characterStats;
    void Awake()
    {
        _characterStats = GetComponent<CharacterStats>();
        _currentHealth = _characterStats.MaxHealth;
    }

    public void CurrentHealthManager(float value){
        if(_currentHealth - value > _characterStats.MaxHealth){ //esto es por si recibes una heal y tu hp final es mayor al hp maximo
            _currentHealth = _characterStats.MaxHealth;
        }
        else{
            _currentHealth -= value;
        }
    }
}
