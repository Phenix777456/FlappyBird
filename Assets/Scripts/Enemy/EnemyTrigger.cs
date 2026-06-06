using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            if (player.TryGetComponent<Health>(out Health playerHealth))
                playerHealth.Decreace(_damage);

        if (gameObject.GetComponent<Health>() == null)
        {
            Destroy(gameObject);
        }
    }
}
