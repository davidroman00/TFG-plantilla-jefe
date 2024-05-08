using UnityEngine;

public class BossHealthManager : MonoBehaviour
{ 
    BossStats _bossStats;
    [SerializeField]
    BossUIHealthManager _bossUIHealthManager;
    float _currentHealth;
    public float CurrentHealth { get { return _currentHealth; } }
    void Start()
    //Usually, you want to initialize scripts in the Awake() method.
    //However, due to Unity's execution order, you need to use the Start() method here, so it doesn't crash.
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
    public void BossRecieveDamage(float value)
    {
        _currentHealth -= value;
        _bossUIHealthManager.SetCurrentHealth(_currentHealth);
    }
}
