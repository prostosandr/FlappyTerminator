using UnityEngine;

public class PlayerBulletSpawner : BulletSpawner
{
    [SerializeField] private Player _player;
    [SerializeField] private float _shootInterval;

    private void Start()
    {
        _player.SetShootInterval(_shootInterval);
    }

    private void OnEnable()
    {
        _player.Spawned += CreateItem;
    }

    private void OnDisable()
    {
        _player.Spawned -= CreateItem;
    }

    protected override void CreateItem()
    {
        SetDirection(Vector2.right);

        base.CreateItem();
    }
}
