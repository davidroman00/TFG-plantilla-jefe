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
        AreaLastsFor();
    }
    void Update()
    {
        AreaDamageManager();
    }
    void OnTriggerEnter(Collider collider)
    {
        _onTrigger = true;
        _collider = collider;
    }
    void OnTriggerExit()
    {
        _onTrigger = false;
        _collider = null;
    }
    void AreaDamageManager()
    {
        if (_onTrigger)
        {
            _collider.GetComponent<CharacterHealthManager>().PlayerCurrentHealthManager(_bossStats.AreaAttackDamagePerSecond);
        }
    }
    IEnumerator AreaLastsFor()
    {
        yield return new WaitForSeconds(_bossStats.AreaDuration);
        Destroy(this);
    }
}
