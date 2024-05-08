using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouseScript : MonoBehaviour
{
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
