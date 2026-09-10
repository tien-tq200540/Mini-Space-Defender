using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawner
{
    [SerializeField] protected float timeToDespawn;

    protected override bool CanDespawn()
    {
        Invoke(nameof(this.DespawnObject), timeToDespawn);
        Debug.Log("InvokeCall");
        return true;
    }

    protected override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
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
