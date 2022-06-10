using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;                     // Hide Cursor
        Cursor.lockState = CursorLockMode.Locked;   // Lock Cursor
    }
}
