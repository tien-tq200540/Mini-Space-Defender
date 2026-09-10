using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs = new();
    [SerializeField] protected List<Transform> objs = new();
    [SerializeField] protected Transform holder;

    protected override void LoadComponents()
    {
        LoadHolder();
    }

    protected virtual Transform Spawn(string prefabName, Vector2 position, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab != null) return Spawn(prefab, position, rotation);
        return null;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform t in prefabs)
        {
            if (t.name.Equals(prefabName)) return t;
        }
        return null;
    }

    protected virtual Transform Spawn(Transform prefab, Vector2 position, Quaternion rotation)
    {
        Transform spawnObj = GetObjFromPool(prefab);
        if (spawnObj == null)
        {
            spawnObj = Instantiate(prefab, position, rotation);
            spawnObj.name = prefab.name;
            spawnObj.SetParent(holder);
        }
        spawnObj.gameObject.SetActive(true);
        return spawnObj;
    }

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach(Transform t in objs)
        {
            if (t.name.Equals(prefab.name))
            {
                objs.Remove(t);
                return t;
            }
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        objs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
    }
}
