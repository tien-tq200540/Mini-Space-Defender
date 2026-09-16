using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDamageSender : DamageSender
{
    [SerializeField] protected PlayerBulletDespawn playerBulletDespawn;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        playerBulletDespawn.DespawnObject();
    }
}
