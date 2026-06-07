using UnityEngine;
using UnityEngine.Pool;

public class PoolOfEnemyes : GenericPool<Enemy>
{
    [SerializeField] private Enemy _prefab;

    [Header("Spawn Settings")]
    [SerializeField] private float _spawnX = 8f;
    [SerializeField] private float _minY = -4f;
    [SerializeField] private float _maxY = 4f;

    protected override Enemy CreateEntity()
    {
        Enemy enemy = Instantiate(_prefab);
        return enemy;
    }

    protected override void SetDirection(Enemy enemy)
    {
        Vector3 position = GetRandomVerticalPosition();

        enemy.transform.position = position;
    }

    private Vector3 GetRandomVerticalPosition()
    {
        float randomY = Random.Range(_minY, _maxY);
        return new Vector3(_spawnX, randomY, 0f);
    }
}