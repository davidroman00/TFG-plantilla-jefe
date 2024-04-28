using UnityEngine;

public class BossAreaWeapon : MonoBehaviour
{
    BossStats _bossStats;
    void Awake()
    {
        _bossStats = FindFirstObjectByType<BossStats>(); 
        //Since this script is applied to a prefab object which is to be instantiated dynamically, you have to initialize 'BossStats' that way.
        //But, be careful if you have more than one script under the same name, and you want to initialize it that way; it won't work correctly.
        Destroy(gameObject, _bossStats.AreaDuration);
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.AreaAttackDamagePerSecond * Time.deltaTime);
        }
    }
}
