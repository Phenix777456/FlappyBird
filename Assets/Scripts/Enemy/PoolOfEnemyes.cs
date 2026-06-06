using UnityEngine;
using UnityEngine.Pool;

public class PoolOfEnemyes : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _maxSize = 50;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: CreateEnemy,
            actionOnGet: OnGetFromPool,
            actionOnRelease: OnReturnToPool,
            actionOnDestroy: OnDestroyEnemy,
            maxSize: _maxSize
        );
    }

    public Enemy Get()
    {
        return _pool.Get();
    }

    public void Return(Enemy enemy)
    {
        _pool.Release(enemy);
    }

    private Enemy CreateEnemy()
    {
        Enemy enemy = Instantiate(_prefab);
        enemy.Initialize(this);
        TryGetComponent<EnemyGunPool>(out EnemyGunPool gunPool);
        enemy.IntitaliseGunPool(gunPool);
        return enemy;
    }

    private void OnGetFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private void OnReturnToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void OnDestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}