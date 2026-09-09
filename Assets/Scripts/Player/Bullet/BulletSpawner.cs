using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 BulletSpawner is allowed to exist");
        instance = this;
        base.Awake();
    }
}
