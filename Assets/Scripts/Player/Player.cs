using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
 
    [SerializeField] private Health _health;

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
