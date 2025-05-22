using System;
using UnityEngine;

[RequireComponent(typeof(EnemyCollisionHandler))]
public class Enemy : MonoBehaviour, IItem<Enemy>
{
    private EnemyCollisionHandler _collisionHandler;

    public event Action<Enemy> Deactivated;

    private void Awake()
    {
        _collisionHandler = GetComponent<EnemyCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += InvokeDeactivated;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= InvokeDeactivated;
    }

    public void InvokeDeactivated()
    {
        Deactivated?.Invoke(this);
    }
}
