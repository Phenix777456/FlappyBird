using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    private Rigidbody2D _playerRb;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    public void Move(float speed) => _playerRb.linearVelocity = new Vector2(-speed, 0);
}
