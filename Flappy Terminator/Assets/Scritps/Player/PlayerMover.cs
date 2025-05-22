using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;

    private InputReader _inputReader;
    private Rigidbody2D _rigidbody2D;

    public event Action Falled;
    public event Action Moved;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.WPressed += Move;
    }

    private void OnDisable()
    {
        _inputReader.WPressed -= Move;
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.linearVelocityY <= 0) 
            Falled?.Invoke();
    }

    public void Move()
    {
        _rigidbody2D.linearVelocity = new Vector2(_speed, _tapForce);

        Moved?.Invoke();
    }
}
