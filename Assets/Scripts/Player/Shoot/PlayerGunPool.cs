using UnityEngine;

public class PlayerGunPool : GenericPool<Bullet>
{
    [SerializeField] private Bullet _heroBullet;
    [SerializeField] private Vector3 _position;

    protected override Bullet CreateEntity()
    {
        Bullet bullet = Instantiate(_heroBullet);

        return bullet;
    }

    protected override void SetDirection(Bullet bullet)
    {
        bullet.transform.position = gameObject.transform.position + _position;
        bullet.SetSpeed(new Vector2(bullet.Speed, 0));
    }
}