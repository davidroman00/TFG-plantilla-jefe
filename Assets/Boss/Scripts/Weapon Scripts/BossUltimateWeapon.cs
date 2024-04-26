using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUltimateWeapon : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>();
    }
    void Update()
    {
        transform.localScale += new Vector3(60 * Time.deltaTime, 60 * Time.deltaTime , 60 * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (this.enabled && collider.GetComponent<CharacterHealthManager>())
        {
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.UltimateAttackDamage);
        }
    }
}
