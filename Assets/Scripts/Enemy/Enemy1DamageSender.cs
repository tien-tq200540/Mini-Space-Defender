using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1DamageSender : DamageSender
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerDamageReceiver playerDamageReceiver))
        {
            playerDamageReceiver.DeductHealth(damage);
        }
    }
}
