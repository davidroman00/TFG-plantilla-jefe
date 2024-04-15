using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIHealthManager : MonoBehaviour
{
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
