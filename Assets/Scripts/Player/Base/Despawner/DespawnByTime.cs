using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawner
{
    [SerializeField] protected float timeToDespawn;

    protected override bool CanDespawn()
    {
        Invoke(nameof(this.DespawnObject), timeToDespawn);
        return true;
    }

    protected override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }

    protected override void LoadComponents()
    {
        CanDespawn();
    }
}
