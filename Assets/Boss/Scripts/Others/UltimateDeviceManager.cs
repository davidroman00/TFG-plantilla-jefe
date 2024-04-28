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
        yield return new WaitForEndOfFrame(); //This line here is needed so Unity has enough time to send the data modifications before this object self destroys
        Destroy(this.gameObject);
    }
}
