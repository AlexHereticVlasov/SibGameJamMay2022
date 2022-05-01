using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStateMachine : MonoBehaviour
{
    private State _currentState;

    public State Current => _currentState;

    public void Init(State state)
    {
        _currentState = state;
        _currentState.Enter();
    }

    public void Transite(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }
}

public abstract class State
{
    protected Player Player;
    protected Checks Checks;
    protected Animator Animator;
    protected PlayerStateMachine StateMachine;
    protected int Hash;
    protected float StartTime;
    protected bool IsAnimationFinished;
    protected bool IsExitingState;
    protected bool IsOnGround;
    protected int XInput;
    protected bool JumpInput;

    public State(Checks checks, Animator animator,Player player,  PlayerStateMachine stateMachine, string animationName)
    {
        Player = player;
        Checks = checks;
        Animator = animator;
        StateMachine = stateMachine;
        Hash = Animator.StringToHash(animationName);

    }

    public virtual void Enter()
    {
        Check();
        Animator.SetBool(Hash, true);
        StartTime = Time.time;
        IsAnimationFinished = false;
        IsExitingState = false;
        Debug.Log(this);
    }

    public virtual void FixedUpdate()
    {
        Check();
    }

    public virtual void Exit()
    {
        Animator.SetBool(Hash, false);
        IsExitingState = true;
        Debug.Log($"{this} exit");
    }

    public virtual void Check()
    {
        IsOnGround = Checks.IsOnGround();
        JumpInput = Checks.IsJumping;
        XInput = Checks.XInput;
    }

}

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

public class LounchState : State
{
    public LounchState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, player, stateMachine, animationName)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Player.Launch();
        StateMachine.Transite(Player.FlyIdleState);
    }
}

public abstract class FlyState : State
{
    protected FlyState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, player, stateMachine, animationName)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (IsOnGround)
        {
            if (XInput == 0)
            {
                StateMachine.Transite(Player.IdleState);
            }
            else
            {
                StateMachine.Transite(Player.MoveState);
            }
        }
        else if (JumpInput == false)
        {
            StateMachine.Transite(Player.FallingState);
        }
    }
}

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

public class FlyMoveState : FlyState
{
    public FlyMoveState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, player, stateMachine, animationName)
    {

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Checks.CheckIfShoudFlip(XInput);
        Player.SetVelocity(Checks.XInput * 2, 2f);
        if (XInput == 0 && !IsExitingState)
        {
            StateMachine.Transite(Player.FlyIdleState);
        }
    }
}

public class FallingState : State
{
    public FallingState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, player, stateMachine, animationName)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Player.ApplyForce(Physics2D.gravity);
        if (IsOnGround)
        {
            if (XInput > 0.1f)
            {
                StateMachine.Transite(Player.MoveState);
            }
            else
            { 
                StateMachine.Transite(Player.IdleState);
            }
        }
        else if (JumpInput)
        {
            if (XInput > 0.1f)
            {
                StateMachine.Transite(Player.FlyMoveState);
            }
            else
            { 
                StateMachine.Transite(Player.FlyIdleState);
            }
        }
    }
}



public class OnEarthInteractState : OnEarthState
{
    public OnEarthInteractState(Checks checks, Animator animator, Player player, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, player, stateMachine, animationName)
    {
    }
}
