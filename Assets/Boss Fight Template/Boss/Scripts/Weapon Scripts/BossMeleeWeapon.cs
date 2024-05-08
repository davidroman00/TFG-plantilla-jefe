using UnityEngine;

public class BossMeleeWeapon : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = GetComponentInParent<BossStats>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (this.enabled == true && collider.CompareTag("Player"))
        {
            //Since this script is in charge of handling all melee attacks, you need to check first which attack is actually being played, so it deals the correct amount of damage.
            if (_bossStats.IsLastMeleePatternAttack)
            {
                collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.PatternMeleeFinalAttackDamage);
            }
            else
            {
                collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.SimpleMeleeAttackDamage);
            }
            this.enabled = false;
            //Disabling this script is necessary in order to deal damage only once per attack.
            //This is enabled through animation events, check the script 'BossAnimationEvents.cs' and the relative animations to learn more.
        }
    }
}