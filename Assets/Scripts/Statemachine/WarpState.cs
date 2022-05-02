using UnityEngine;

public class WarpState : State
{
    private float _length;

    public WarpState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
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
            Player.WarpBack();
            StateMachine.Transite(Player.IdleState);
        }
    }
}

