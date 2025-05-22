using UnityEngine;

public class BulletCatcher : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
            bullet.InvokeDeactivated();
    }
}
