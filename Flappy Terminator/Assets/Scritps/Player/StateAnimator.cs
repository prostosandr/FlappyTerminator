using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StateAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public enum States
    {
        Idle = 0,
        Up = 1,
        Attack = 2
    }

    public void SetIdleAnimation()
    {
        SetAnimation((int)States.Idle);
    }

    public void SetUpAnimation()
    {
        SetAnimation((int)States.Up);
    }

    public void SetAttackAnimation()
    {
        SetAnimation((int)States.Attack);
    }

    private void SetAnimation(int value)
    {
        _animator.SetInteger(PlayerAnimatorData.Params.State, value);
    }
}
