using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        PlayerBulletSpawner.Instance.Despawn(transform.parent);
    }
}
