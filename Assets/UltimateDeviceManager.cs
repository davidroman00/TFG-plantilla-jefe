using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateDeviceManager : MonoBehaviour
{
    void OnTriggerEnter()
    {
        Destroy(this.gameObject);
    }
}
