using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private AbstractInventory _inventory;
    [SerializeField] private Checks _checks;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;

    private PlayerStateMachine _stateMachine;

    public event UnityAction Dead;

    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public FlyIdleState FlyIdleState { get; private set; }
    public FlyMoveState FlyMoveState { get; private set; } 
    public LounchState LounchState { get; private set; }
    public FallingState FallingState { get; private set; }
    public OnEarthInteractState OnEarthInteractState { get; private set; }
    public InAirInteractionState InAirInteractionState { get; private set; }
    public WarpState WarpState { get; private set; }
    //public AbstractInventory Inventory => _inventory;

    private void Awake()
    {
        _stateMachine = GetComponent<PlayerStateMachine>();
        IdleState = new IdleState(_checks, _animator, this, _stateMachine, "Idle");
        MoveState = new MoveState(_checks, _animator, this, _stateMachine, "Move");
        LounchState = new LounchState(_checks, _animator, this, _stateMachine, "Lounch");
        FlyIdleState = new FlyIdleState(_checks, _animator, this, _stateMachine, "FlyIdle");
        FlyMoveState = new FlyMoveState(_checks, _animator, this, _stateMachine, "FlyMove");
        FallingState = new FallingState(_checks, _animator, this, _stateMachine, "Falling");
        OnEarthInteractState = new OnEarthInteractState(_checks, _animator, this, _stateMachine, "EarthInteract");
        InAirInteractionState = new InAirInteractionState(_checks, _animator, this, _stateMachine, "InAirInteract");
        WarpState = new WarpState(_checks, _animator, this, _stateMachine, "Warp");

        _stateMachine.Init(IdleState);
    }

    private void FixedUpdate()
    {
        _stateMachine.Current.FixedUpdate();
    }

    internal void Die()
    {
        Dead?.Invoke();
        _stateMachine.Transite(WarpState);
    }

    internal void SetVelocityX(float v)
    {
        _rigidbody.velocity = new Vector2(v, _rigidbody.velocity.y);
    }

    internal void SetVelocity(float v1, float v2)
    {
        _rigidbody.velocity = new Vector2(v1, v2);
    }

    public void Launch()
    {
        _rigidbody.AddForce(Vector2.up * 1, ForceMode2D.Impulse);
    }

    internal void ApplyForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    internal void WarpBack()
    {
        //ToDo:PlayParticles
        transform.position = Vector2.zero;
    }
}
