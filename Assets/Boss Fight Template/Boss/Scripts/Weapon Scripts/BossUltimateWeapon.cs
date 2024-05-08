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
        //This object grows at a constant rate.
        transform.localScale += new Vector3(120 * Time.deltaTime, 120 * Time.deltaTime , 120 * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<CharacterHealthManager>().PlayerRecieveDamage(_bossStats.UltimateAttackDamage);
        }
    }
}