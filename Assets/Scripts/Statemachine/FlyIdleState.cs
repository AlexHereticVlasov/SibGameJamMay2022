using UnityEngine;

public class FlyIdleState : FlyState
{
    public FlyIdleState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
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

