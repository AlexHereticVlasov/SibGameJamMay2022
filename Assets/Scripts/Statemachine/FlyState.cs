using UnityEngine;

public abstract class FlyState : State
{
    protected FlyState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (IsOnGround)
        {
            if (XInput == 0)
            {
                StateMachine.Transite(Player.IdleState);
            }
            else
            {
                StateMachine.Transite(Player.MoveState);
            }
        }
        else if (JumpInput == false)
        {
            StateMachine.Transite(Player.FallingState);
        }
    }
}

