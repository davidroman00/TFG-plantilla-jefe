using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{ //podria ser el mismo script de recibir daño en el pj y el boss, pero de esta manera se separa una logica de la otra por si acaso se quiere hacer algo diferente para ambos (formula de recibir daño...)
    BossStats _bossStats;
    [SerializeField]
    BossUIHealthManager _bossUIHealthManager;
    float _currentHealth;
    public float CurrentHealth { get { return _currentHealth; } }
    void Start()//por el orden de ejecución aqui hay que usar start en vez de awake, si no, el script se apaga al comienzo del juego
    {
        _bossStats = GetComponentInParent<BossStats>();
        _currentHealth = _bossStats.BossMaxHP;
        _bossUIHealthManager.SetMaxHealth(_currentHealth);
        _bossUIHealthManager.SetCurrentHealth(_currentHealth);
    }
    void Update()
    {
        if (_currentHealth <= 0 && this.gameObject.name == "BossCollisionsManagerPhase2"){
            GetComponentInParent<Animator>().SetTrigger("death"); 
        }
    }

    public void EnemyRecieveDamage(float value)
    {
        _currentHealth -= value;
        _bossUIHealthManager.SetCurrentHealth(_currentHealth);

    }
}
