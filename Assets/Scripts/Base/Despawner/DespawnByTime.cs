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

    protected override void LoadComponents()
    {
    }

    private void OnEnable()
    {
        CanDespawn();
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(this.DespawnObject));
    }
}
