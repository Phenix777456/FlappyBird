using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;

    public void SetSpeed(Vector2 speed)
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = speed;
    }
}
