using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStateMachine : MonoBehaviour
{
    private State _firstState;
    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        Reset(_firstState);
    }

    private void Reset(State state)
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
    protected Checks Checks;
    protected Animator Animator;
    protected PlayerStateMachine StateMachine;
    protected int Hash;
    protected float StartTime;
    protected bool IsAnimationFinished;
    protected bool IsExitingState;

    public State(Checks checks, Animator animator, PlayerStateMachine stateMachine, string animationName)
    {
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
    }

    public virtual void FixedUpdate()
    {
        Check();
    }

    public virtual void Exit()
    {
        Animator.SetBool(Hash, false);
        IsExitingState = true;
    }

    public virtual void Check()
    { 
    
    }

}

public abstract class OnEarthState : State
{
    protected int XInput;
    private bool _jumpInput;
    private bool _isOnGround;

    public OnEarthState(Checks checks, Animator animator, PlayerStateMachine stateMachine, string animationName) : base(checks, animator, stateMachine, animationName)
    { }

    public override void Check()
    {
        _isOnGround = Checks.IsOnGround();
        _jumpInput = Checks.IsJumping;
        XInput = Checks.XInput;
    }
}

public class Checks : MonoBehaviour
{
    const float GroundedRadius = .2f;

    private float _xInput;
    private bool _isJumping;

    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;

    public int XInput => (int)Mathf.Abs(_xInput);
    public bool IsJumping => _isJumping;


    public bool IsOnGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GroundedRadius, _whatIsGround);

        foreach (var collider in colliders)
            if (collider.gameObject != gameObject)
                return true;

        return false;
    }

    public void SetXInput(int value) => _xInput = value;

    public void SetIsJumping(bool value) => _isJumping = value;
}
