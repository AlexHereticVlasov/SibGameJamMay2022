using UnityEngine;

public class FallingState : State
{
    public FallingState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, player, stateMachine, animationName)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Player.ApplyForce(Physics2D.gravity);
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

