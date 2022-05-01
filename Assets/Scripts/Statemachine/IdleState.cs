using UnityEngine;

public class IdleState : OnEarthState
{
    public IdleState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (XInput != 0 && !IsExitingState)
        {
            StateMachine.Transite(Player.MoveState);
        }
       
    }
}

