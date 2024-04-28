using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMeleeWeapon : MonoBehaviour
{
    CharacterStats _characterStats;
    void Awake()
    {
        _characterStats = GetComponentInParent<CharacterStats>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<BossHealthManager>() && this.enabled)
        {
            collider.GetComponent<BossHealthManager>().EnemyRecieveDamage(_characterStats.AttackDamage);
            this.enabled = false;
            //Disabling this script is necessary in order to deal damage only once per attack.
            //This is enabled through animation events, check the script 'CharacterAnimationEvents.cs' and the relative animation to learn more
        }
    }
}
