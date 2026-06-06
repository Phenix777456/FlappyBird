using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PoolOfEnemyes _pool;

    [Header("Spawn Settings")]
    [SerializeField] private float _spawnX = 8f;
    [SerializeField] private float _minY = -4f;
    [SerializeField] private float _maxY = 4f;
    [SerializeField] private float _spawnDellay;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomVerticalPosition();

        Enemy enemy = _pool.Get();
        enemy.transform.position = spawnPosition;

        StartCoroutine(ShootDellay(_spawnDellay));
    }

    private IEnumerator ShootDellay(float dellay)
    {
        WaitForSeconds finalDellay = new WaitForSeconds(dellay);
        yield return finalDellay;

        SpawnEnemy();
    }

    private Vector3 GetRandomVerticalPosition()
    {
        float randomY = Random.Range(_minY, _maxY);
        return new Vector3(_spawnX, randomY, 0f);
    }
}