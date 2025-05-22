using UnityEngine;

public abstract class BulletSpawner : Spawners<Bullet>
{
    [SerializeField] private float _bulletSpeed;
   
    private Vector2 _direction;

    public void SetDirection(Vector2 newDirection)
    {
        _direction = newDirection;
    }

    protected override void CreateItem()
    {
        Bullet bullet = GetObject();
        bullet.SetSpeed(_bulletSpeed);
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
        bullet.Move(_direction);
    }
}
