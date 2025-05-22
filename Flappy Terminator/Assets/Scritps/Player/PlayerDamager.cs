using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerDamager : MonoBehaviour
{
    private InputReader _inputReader;
    private Coroutine _coroutine;

    public event Action<bool> Attacked;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.DPressed += Attack;
    }

    private void OnDisable()
    {
        _inputReader.DPressed -= Attack;
    }

    private void Attack()
    {
        _inputReader.DPressed -= Attack;

        float time = 0.15f;
        var wait = new WaitForSeconds(time);

        Attacked?.Invoke(true);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Attack(wait));
    }

    private IEnumerator Attack(WaitForSeconds wait)
    {
        yield return wait;

        Attacked?.Invoke(false);

        _inputReader.DPressed += Attack;
    }
}
