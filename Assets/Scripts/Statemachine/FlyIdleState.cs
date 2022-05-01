using UnityEngine;

public class FlyIdleState : FlyState
{
    public FlyIdleState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, player, stateMachine, animationName)
    {
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Player.SetVelocity(0, 2f);


        if (XInput != 0 && !IsExitingState)
        {
            StateMachine.Transite(Player.FlyMoveState);
        }
    }

}

