using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealthManager : MonoBehaviour
{
    float _currentHealth;
    CharacterStats _characterStats;
    [SerializeField]
    CharacterUIHealthManager _characterUIHealth;
    void Awake()
    {
        _characterStats = GetComponent<CharacterStats>();
        _currentHealth = _characterStats.MaxHealth;
        _characterUIHealth.SetMaxHealth(_characterStats.MaxHealth);
        _characterUIHealth.SetCurrentHealth(_characterStats.MaxHealth);
    }
    void Update()
    {
        if (_currentHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CurrentHealthManager(float value)
    {
        if (_currentHealth - value > _characterStats.MaxHealth)
        { //esto es por si recibes una heal y tu hp final es mayor al hp maximo
            _currentHealth = _characterStats.MaxHealth;
            _characterUIHealth.SetCurrentHealth(_characterStats.MaxHealth);
        }
        else
        {
            _currentHealth -= value;
            _characterUIHealth.SetCurrentHealth(_currentHealth - value);
        }
    }
    //usar en caso de querer alterar la maxHealth del personaje de forma dinámica
    /*public void MaxHealthChange(float value){
        _characterStats.MaxHealth += value;
        _characterUIHealth.SetMaxHealth(_characterStats.MaxHealth + value);
    }*/
}
