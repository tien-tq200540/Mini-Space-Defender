using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [SerializeField] protected int damage = 10;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DamageReceiver damageReceiver))
        {
            damageReceiver.DeductHealth(damage);
        }
    }
}
