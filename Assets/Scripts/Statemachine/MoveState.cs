using UnityEngine;

public class MoveState : OnEarthState
{
    public MoveState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Checks.CheckIfShoudFlip(XInput);
        Player.SetVelocityX(Config.SpeedOnGround * XInput);

        if (XInput == 0 && !IsExitingState)
        {
            StateMachine.Transite(Player.IdleState);
        }
    }
}

