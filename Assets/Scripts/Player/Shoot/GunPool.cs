using UnityEngine;
using UnityEngine.Pool;

public abstract class GunPool<TBullet> : MonoBehaviour where TBullet : Bullet
{
    [SerializeField] protected TBullet _prefab;
    [SerializeField] private int _maxSize = 30;

    private ObjectPool<TBullet> _bulletPool;
    private Transform _spawnPoint;
    private float _tweaking;

    private void Awake()
    {
        _bulletPool = new ObjectPool<TBullet>(
            createFunc: CreateBullet,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyBullet,
            maxSize: _maxSize
        );
    }


    public void SetSpawnPoint(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public void Spawn(Transform spawnPoint)
    {
        TBullet bullet = _bulletPool.Get();
        bullet.transform.position = spawnPoint.position + new Vector3(_tweaking, 0f, 0f);
    }

    public void Return(TBullet bullet)
    {
        _bulletPool.Release(bullet);
    }

    protected abstract void SetDirection(TBullet bullet);

    protected void SetTweaking(float tweaking)
    {
        _tweaking = tweaking;
    }

    private TBullet CreateBullet()
    {
        TBullet bullet = Instantiate(_prefab);
        return bullet;
    }

    private void OnGet(TBullet bullet)
    {
        bullet.gameObject.SetActive(true);
        SetDirection(bullet);
    }

    private void OnRelease(TBullet bullet)
    {
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(TBullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}