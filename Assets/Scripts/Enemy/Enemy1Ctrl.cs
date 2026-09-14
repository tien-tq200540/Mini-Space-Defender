using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Ctrl :TienMonoBehaviour
{
    [SerializeField] protected Enemy1Despawn enemy1Despawn;
    public Enemy1Despawn Enemy1Despawn => enemy1Despawn;

    protected override void LoadComponents()
    {
        LoadEnemy1Despawn();
    }

    protected virtual void LoadEnemy1Despawn()
    {
        if (enemy1Despawn != null) return;
        enemy1Despawn = transform.GetComponentInChildren<Enemy1Despawn>();
    }
}
