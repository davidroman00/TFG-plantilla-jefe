using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    public void OnAttackStart()
    {
        GetComponentInChildren<WeaponDamageManager>().enabled = true;
    }
    public void OnMidAttack()
    {
        GetComponentInChildren<WeaponDamageManager>().enabled = false;
    }
}
