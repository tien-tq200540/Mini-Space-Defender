using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    private void Awake()
    {
        speed = 5f;
    }

    private void ResetValue()
    {
        transform.parent.position = Vector3.zero;
    }

    private void FixedUpdate()
    {
        transform.parent.Translate(Vector3.up * speed * Time.fixedDeltaTime);
    }

    private void OnDisable()
    {
        ResetValue();
    }
}
