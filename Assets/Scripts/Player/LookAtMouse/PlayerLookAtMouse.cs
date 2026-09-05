using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLookAtMouse : MonoBehaviour
{
    private void Update()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0f;
        Vector3 direction = mouseWorldPos - transform.parent.position;
        float offset = -90f;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;
        Quaternion rot = Quaternion.Euler(0f, 0f, angle);
        transform.parent.rotation = rot;
    }
        
}
