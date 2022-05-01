using UnityEngine;

public class LounchState : State
{
    public LounchState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName, PlayerConfig config) : base(checks, animator, player, stateMachine, animationName, config)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Player.Launch();
        StateMachine.Transite(Player.FlyIdleState);
    }
}

