using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateDeviceManager : MonoBehaviour
{
    bool _isDeviceDestroyed;
    public bool IsDeviceDestroyed { get { return _isDeviceDestroyed; } }
    void Awake()
    {
        _isDeviceDestroyed = false;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _isDeviceDestroyed = true;
            StartCoroutine(WaitForDestroy());
        }
    }
    IEnumerator WaitForDestroy()
    {
        yield return new WaitForEndOfFrame();//necesario para que le de tiempo al otro script a recibir la data
        Destroy(this.gameObject);
    }
}
