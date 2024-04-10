using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIHealthManager : MonoBehaviour
{
    [SerializeField]
    Slider _healthSlider;

    public void SetMaxHealth(float maxHealth){
        _healthSlider.maxValue = maxHealth;
    }
    public void SetCurrentHealth(float currentHealth){
        _healthSlider.value = currentHealth;
    }
}
