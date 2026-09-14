using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1DamageReceiver : DamageReceiver
{
    [SerializeField] protected Enemy1Ctrl enemy1Ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemy1Ctrl();
    }

    private void LoadEnemy1Ctrl()
    {
        if (enemy1Ctrl != null) return;
        enemy1Ctrl = transform.GetComponentInParent<Enemy1Ctrl>();
    }

    protected override void Death()
    {
        enemy1Ctrl.Enemy1Despawn.DespawnObject();
    }
}
