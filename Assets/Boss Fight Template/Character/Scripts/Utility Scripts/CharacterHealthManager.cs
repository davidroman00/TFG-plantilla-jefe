using System.Collections;
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
    void Start()
    //Usually, you want to initialize scripts in the Awake() method.
    //However, due to Unity's execution order, you need to use the Start() method here, so it doesn't crash.
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
    //This is a public method since it needs to be accessed from other objects
    {
        _currentHealth -= value;
        _characterHealthUI.SetCurrentHealth(_currentHealth);
    }
}