using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Despawn : DespawnByTime
{
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
