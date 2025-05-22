using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerDamager))]
[RequireComponent(typeof(StateAnimator))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private PlayerDamager _damager;
    private StateAnimator _stateAnimator;
    private Coroutine _coroutine;
    private bool _canAttack;
    private bool _canShoot;
    private float _shootInterval;

    public event Action Spawned;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _damager = GetComponent<PlayerDamager>();
        _stateAnimator = GetComponent<StateAnimator>();
    }

    private void Start()
    {
        _canShoot = true;
    }

    private void OnEnable()
    {
        _mover.Falled += Fall;
        _mover.Moved += Move;
        _damager.Attacked += SetIsAttack;
    }

    private void OnDisable()
    {
        _mover.Falled -= Fall;
        _mover.Moved -= Move;
        _damager.Attacked -= SetIsAttack;
    }

    public void SetShootInterval(float value)
    {
        _shootInterval = value;
    }

    private void SetIsAttack(bool value)
    {
        _canAttack = value;

        if (_canAttack && _canShoot)
        {
            var wait = new WaitForSeconds(_shootInterval);

            _canShoot = false;

            _stateAnimator.SetAttackAnimation();

            Spawned?.Invoke();

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(StartShootInterval(wait));
        }
    }

    private void Fall()
    {
        if (_canAttack == false)
            _stateAnimator.SetIdleAnimation();
    }

    private void Move()
    {
        if (_canAttack == false)
            _stateAnimator.SetUpAnimation();
    }

    private IEnumerator StartShootInterval(WaitForSeconds wait)
    {
        yield return wait;

        _canShoot = true;
    }
}
