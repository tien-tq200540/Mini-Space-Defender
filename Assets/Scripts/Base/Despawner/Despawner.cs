public abstract class Despawner : TienMonoBehaviour
{
    protected abstract bool CanDespawn();
    public virtual void DespawnObject()
    {
        Destroy(gameObject);
    }
}