using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class GenericPool<TEntity> : MonoBehaviour where TEntity : MonoBehaviour
{
    [SerializeField] private int _maxSize = 30;

    private ObjectPool<TEntity> _bulletPool;

    private void Awake()
    {
        _bulletPool = new ObjectPool<TEntity>(
            createFunc: CreateEntity,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyBullet,
            maxSize: _maxSize
        );
    }

    public void Spawn()
    {
        TEntity entity = _bulletPool.Get();
        SetDirection(entity);
    }

    public void Return(TEntity entity)
    {
        _bulletPool.Release(entity);
    }

    protected abstract void SetDirection(TEntity entity);

    protected abstract TEntity CreateEntity();
   

    private void OnGet(TEntity entity)
    {
        entity.gameObject.SetActive(true);
    }

    private void OnRelease(TEntity entity)
    {
        entity.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(TEntity entity)
    {
        Destroy(entity.gameObject);
    }
}