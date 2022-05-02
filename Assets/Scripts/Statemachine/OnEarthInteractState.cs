using UnityEngine;

public class OnEarthInteractState : State
{
    private float _length;
    private IInteractable _interactable;

    public OnEarthInteractState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _length = Animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _length -= Time.fixedDeltaTime;
        Player.SetVelocity(0, 0);
        if (_length <= 0)
        {
            _interactable.Interact();
            StateMachine.Transite(Player.IdleState);
        }

    }

    public void SetInteractable(IInteractable interactable)
    {
        _interactable = interactable;
    }
}

