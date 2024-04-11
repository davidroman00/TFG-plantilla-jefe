using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossAreaWeapon : MonoBehaviour
{
    BossStats _bossStats;
    Collider _collider;
    bool _onTrigger;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
        Destroy(gameObject, _bossStats.AreaDuration);
    }
    void Update()
    {
        AreaDamageManager();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _onTrigger = true;
            _collider = collider;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _onTrigger = false;
            _collider = null;
        }
    }
    void AreaDamageManager()
    {
        if (_onTrigger)
        {
            _collider.GetComponent<CharacterHealthManager>().PlayerCurrentHealthManager(_bossStats.AreaAttackDamagePerSecond);
        }
    }   
}
