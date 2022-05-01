using UnityEngine;

public abstract class OnEarthState : State
{
    public OnEarthState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
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

