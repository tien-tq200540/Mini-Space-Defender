using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    private void FixedUpdate()
    {
        transform.parent.Translate(Vector3.up * speed * Time.fixedDeltaTime);
    }
}
