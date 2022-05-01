using UnityEngine;

public class FlyMoveState : FlyState
{
    public FlyMoveState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
    {

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Checks.CheckIfShoudFlip(XInput);
        Player.SetVelocity(Checks.XInput * Config.SpeedInAir, 2f);//InAir
        if (XInput == 0 && !IsExitingState)
        {
            StateMachine.Transite(Player.FlyIdleState);
        }
    }
}

