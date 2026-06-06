using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyGunPool _gunPool;
    [SerializeField] private float _dellay;
    [SerializeField] private float _speed;
    [SerializeField] private Health _health;

    private EnemyMover _enemyMover;

    private PoolOfEnemyes _pool;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void OnEnable()
    {
        _health.Deaded += OnDead;
    }

    public void Start()
    {
        StartCoroutine(ShootDellay(_dellay));
    }

    private void Update()
    {
        _enemyMover.Move(_speed);
    }

    private void OnDisable()
    {
        _health.Deaded -= OnDead;
    }

    public void IntitaliseGunPool(EnemyGunPool gunPool)
    {
        _gunPool = gunPool;

    }

    public void Initialize(PoolOfEnemyes pool)
    {
        _pool = pool;
    }

    private void OnDead() => Destroy(gameObject);

    private IEnumerator ShootDellay(float dellay)
    {
        WaitForSeconds finalDellay = new WaitForSeconds(dellay);
        yield return finalDellay;

        _gunPool.Spawn(gameObject.transform);

        StartCoroutine(ShootDellay(_dellay));
    }
}