using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            if (enemy.TryGetComponent<Health>(out Health playerHealth))
                playerHealth.Decreace(_damage);

        if (gameObject.GetComponent<Health>() == null)
        {
            Destroy(gameObject);
        }
    }
}
