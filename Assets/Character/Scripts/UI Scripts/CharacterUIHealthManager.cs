using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIHealthManager : MonoBehaviour
{
    //This script is exactly the same as 'BossUIHealthManager'.
    //However, it is better to keep them as different scripts in case you wanted to alter the character UI differently as the boss one.
    Slider _healthSlider;
    void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }
    public void SetMaxHealth(float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
    }
    public void SetCurrentHealth(float currentHealth)
    {
        _healthSlider.value = currentHealth;
    }
}
