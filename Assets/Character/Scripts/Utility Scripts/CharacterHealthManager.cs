using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealthManager : MonoBehaviour
{
    float _currentHealth;
    CharacterStats _characterStats;
    [SerializeField]
    CharacterUIHealthManager _characterHealthUI;
    [SerializeField]
    GameObject _deathTextUI;
    void Start()//por el orden de ejecución aqui hay que usar start en vez de awake, si no, el script se apaga al comienzo del juego
    {
        _characterStats = GetComponent<CharacterStats>();
        _currentHealth = _characterStats.MaxHealth;
        _characterHealthUI.SetMaxHealth(_currentHealth);
        _characterHealthUI.SetCurrentHealth(_currentHealth);
    }
    void Update()
    {
        if (_currentHealth <= 0)
        {
            StartCoroutine(CheckDeath());
        }
    }
    IEnumerator CheckDeath()
    {
        _deathTextUI.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
    public void PlayerRecieveDamage(float value)
    {
        _currentHealth -= value;
        _characterHealthUI.SetCurrentHealth(_currentHealth);
    }
}
