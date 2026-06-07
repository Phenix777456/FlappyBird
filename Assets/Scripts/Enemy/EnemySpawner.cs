using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PoolOfEnemyes _poolOfEnemyes;
    [SerializeField] private float _dellay;

    void Start()
    {
        _poolOfEnemyes.Spawn();
        StartCoroutine(DellaySpawn(_dellay));
    }

    private IEnumerator DellaySpawn(float dellday)
    {
        WaitForSeconds finalDellay = new WaitForSeconds(dellday);

        yield return finalDellay;

        _poolOfEnemyes.Spawn();
        StartCoroutine(DellaySpawn(dellday));
    }
   
}
