using UnityEngine;

public class EnemyCatcher : BulletCatcher
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.TryGetComponent(out Enemy enemy))
            enemy.InvokeDeactivated();
    }
}
