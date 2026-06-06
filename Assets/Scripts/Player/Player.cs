using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerGunPool _gunPool;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _gunPool.SetSpawnPoint(gameObject.transform);
    }

    private void OnEnable()
    {
        _health.Deaded += OnDead;
    }

    private void OnDisable()
    {
        _health.Deaded -= OnDead;
    }

    private void OnDead() => Destroy(gameObject);
}
