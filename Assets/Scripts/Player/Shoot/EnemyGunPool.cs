using UnityEngine;

public class EnemyGunPool : GenericPool<Bullet>
{
    [SerializeField] private Bullet _enemyBullet;
    [SerializeField] private Vector3 _position;

    protected override Bullet CreateEntity()
    {
        Bullet bullet = Instantiate(_enemyBullet);

        return bullet;
    }

    protected override void SetDirection(Bullet bullet)
    {
        bullet.transform.position = gameObject.transform.position - _position;
        bullet.SetSpeed(new Vector2(-bullet.Speed, 0));
    }
}