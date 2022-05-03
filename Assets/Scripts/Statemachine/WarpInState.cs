using UnityEngine;

public class WarpInState : State
{
    private float _length;

    public WarpInState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _length = Animator.GetCurrentAnimatorStateInfo(0).length;
        Player.SetVelocity(0, 0);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _length -= Time.fixedDeltaTime;
        if (_length <= 0)
        {
            StateMachine.Transite(Player.WarpOutState);
            Player.WarpBack();
        }
    }
}

public class WarpOutState : State
{
    private float _length;

    public WarpOutState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _length = Animator.GetCurrentAnimatorStateInfo(0).length;
        Player.SetVelocity(0, 0);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _length -= Time.fixedDeltaTime;
        if (_length <= 0)
        {
            //Player.WarpBack();
            StateMachine.Transite(Player.IdleState);
        }
    }
}

