using UnityEngine;

public abstract class OnEarthState : State
{
    public OnEarthState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator,player, stateMachine, animationName)
    { }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (IsOnGround == false)
        {
            StateMachine.Transite(Player.FallingState);
        }
        else if (JumpInput)
        {
            StateMachine.Transite(Player.LounchState);
        }
    }
}

