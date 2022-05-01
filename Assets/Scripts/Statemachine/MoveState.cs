using UnityEngine;

public class MoveState : OnEarthState
{
    public MoveState(Checks checks, Animator animator,Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, player, stateMachine, animationName)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Checks.CheckIfShoudFlip(XInput);
        Player.SetVelocityX(2 * XInput); // Movement Speed

        if (XInput == 0 && !IsExitingState)
        {
            StateMachine.Transite(Player.IdleState);
        }
    }
}

