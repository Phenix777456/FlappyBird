using UnityEngine;

public class EnemyGunPool : GunPool<Bullet>
{
    private float _thisTweaking = -1;

    protected override void SetDirection(Bullet bullet)
    {
        bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-bullet.Speed, 0);
        this.SetTweaking(_thisTweaking);
    }
}