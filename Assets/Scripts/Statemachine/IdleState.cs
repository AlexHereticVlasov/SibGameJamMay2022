using UnityEngine;

public class IdleState : OnEarthState
{
    public IdleState(Checks checks, Animator animator,Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator,player, stateMachine, animationName)
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

