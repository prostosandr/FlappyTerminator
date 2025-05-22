using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawners<Enemy>
{
    [SerializeField] Collider2D _startPosition;
    [SerializeField] private float _spawnInterval;

    private void Start()
    {
        var wait = new WaitForSeconds(_spawnInterval);

        StartCoroutine(Spawn(wait));
    }
    protected override void CreateItem()
    {
        Enemy enemy = GetObject();
        enemy.transform.position = GetSpawnPosition();
        enemy.gameObject.SetActive(true);
    }

    private IEnumerator Spawn(WaitForSeconds wait)
    {
        while (enabled)
        {
            int numberOfEnemys = Random.Range(0, 3);

            for (int i = 0; i <= numberOfEnemys; i++)
            {
                Spawn();
            }

            yield return wait;
        }
    }

    private Vector2 GetSpawnPosition()
    {
        Bounds bound = _startPosition.bounds;

        return new Vector2(
            Random.Range(bound.min.x, bound.max.x),
            Random.Range(bound.min.y, bound.max.y)
            );
    }
}
