using System.Collections;
using UnityEngine;

public class EnemyBulletSpawner : BulletSpawner
{
    [SerializeField] private float _spawnInterval;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        var wait = new WaitForSeconds(_spawnInterval);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SpawnBullet(wait));
    }

    protected override void CreateItem()
    {
        SetDirection(Vector2.left);

        base.CreateItem();
    }

    private IEnumerator SpawnBullet(WaitForSeconds wait)
    {
        while(enabled)
        {
            CreateItem();

            yield return wait;
        }
    }
}
