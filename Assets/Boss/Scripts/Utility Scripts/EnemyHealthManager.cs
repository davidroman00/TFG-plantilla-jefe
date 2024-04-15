using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{ //podria ser el mismo script de recibir daño en el pj y el boss, pero de esta manera se separa una logica de la otra por si acaso se quiere hacer algo diferente para ambos (formula de recibir daño...)
    float _currentHealth;
    BossStats _bossStats;
    [SerializeField]
    BossUIHealthManager _bossUIHealthManager;
    void Start()//por el orden de ejecución aqui hay que usar start en vez de awake, si no, el script se apaga al comienzo del juego
    {
        _bossStats = GetComponent<BossStats>();
        _currentHealth = _bossStats.BossMaxHP;
        _bossUIHealthManager.SetMaxHealth(_currentHealth);
        _bossUIHealthManager.SetCurrentHealth(_currentHealth);
    }

    public void EnemyRecieveDamage(float value)
    {
        _currentHealth -= value;
        _bossUIHealthManager.SetCurrentHealth(_currentHealth);
        Debug.Log(_currentHealth);
    }
}
