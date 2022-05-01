using UnityEngine;

public class FlyMoveState : FlyState
{
    public FlyMoveState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, player, stateMachine, animationName)
    {

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Checks.CheckIfShoudFlip(XInput);
        Player.SetVelocity(Checks.XInput * 2, 2f);//InAir
        if (XInput == 0 && !IsExitingState)
        {
            StateMachine.Transite(Player.FlyIdleState);
        }
    }
}

