using UnityEngine;

public class FallingState : State
{
    public FallingState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Player.ApplyForce(Config.Gravity);
        if (IsOnGround)
        {
            if (XInput > 0.1f)
                StateMachine.Transite(Player.MoveState);
            else
                StateMachine.Transite(Player.IdleState);
        }
        else if (JumpInput)
        {
            if (XInput > 0.1f)
                StateMachine.Transite(Player.FlyMoveState);
            else
                StateMachine.Transite(Player.FlyIdleState);
        }
    }
}

