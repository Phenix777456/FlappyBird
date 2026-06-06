using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour 
{
    private Rigidbody2D _playerRb;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    public void Move(float jumpForce) => _playerRb.linearVelocity = new Vector2(0, jumpForce);

}
