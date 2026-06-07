using UnityEngine;

public class GenericTrigger<TEntity> : MonoBehaviour where TEntity : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<TEntity>(out TEntity entity))
            if (entity.TryGetComponent<Health>(out Health playerHealth))
                playerHealth.Decreace(_damage);

        if (gameObject.GetComponent<Health>() == null)
        {
            Destroy(gameObject);
        }
    }
}