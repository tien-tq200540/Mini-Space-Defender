public abstract class Despawner : TienMonoBehaviour
{
    protected abstract bool CanDespawn();
    protected abstract void DespawnObject();
}