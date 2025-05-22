using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IItem<Bullet>  
{
    private float _speed;
    private Coroutine _coroutine;

    public event Action<Bullet> Deactivated;

    public void InvokeDeactivated()
    {
        Deactivated?.Invoke(this);
    }

    public void Move(Vector2 direction)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MoveEnumerator(direction));
    }

    public void SetSpeed(float value)
    {
        _speed = value;
    }

    private IEnumerator MoveEnumerator(Vector2 direction)
    {
        while(enabled)
        {
            transform.Translate(_speed * Time.deltaTime * direction);
            yield return null;
        }
    }
}
