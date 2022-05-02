using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private Checks _checks;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;

    //[Header("Particles, Make some class for it")]
    //[SerializeField] ParticleSystem _closePortal;
    //[SerializeField] ParticleSystem _openPortal;
    //private readonly Quaternion _particleRotation = Quaternion.Euler(-90, 0, 0);


    private PlayerStateMachine _stateMachine;

    public event UnityAction Dead;
    public event UnityAction<SaveZone> EnterInSaveZone;
    public event UnityAction ExitFromSaveZone;
    public event UnityAction Warped;

    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public FlyIdleState FlyIdleState { get; private set; }
    public FlyMoveState FlyMoveState { get; private set; } 
    public LounchState LounchState { get; private set; }
    public FallingState FallingState { get; private set; }
    public OnEarthInteractState OnEarthInteractState { get; private set; }
    public InAirInteractionState InAirInteractionState { get; private set; }
    public WarpInState WarpState { get; private set; }

    private void Awake()
    {
        _stateMachine = GetComponent<PlayerStateMachine>();
        IdleState = new IdleState(_checks, _animator, this, _stateMachine, "Idle", _config);
        MoveState = new MoveState(_checks, _animator, this, _stateMachine, "Move", _config);
        LounchState = new LounchState(_checks, _animator, this, _stateMachine, "Lounch", _config);
        FlyIdleState = new FlyIdleState(_checks, _animator, this, _stateMachine, "FlyIdle", _config);
        FlyMoveState = new FlyMoveState(_checks, _animator, this, _stateMachine, "FlyMove", _config);
        FallingState = new FallingState(_checks, _animator, this, _stateMachine, "Falling", _config);
        OnEarthInteractState = new OnEarthInteractState(_checks, _animator, this, _stateMachine, "EarthInteract", _config);
        InAirInteractionState = new InAirInteractionState(_checks, _animator, this, _stateMachine, "InAirInteract", _config);
        WarpState = new WarpInState(_checks, _animator, this, _stateMachine, "Warp", _config);

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
        //ToDo: Particle Spawn
        //var openPortal = Instantiate(_openPortal, transform.position, _particleRotation);
        //Destroy(openPortal.gameObject, 5);
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
        Warped?.Invoke();
        //var closePortal = Instantiate(_closePortal, transform.position, _particleRotation);
        //Destroy(closePortal.gameObject, 5);
        //transform.position = Vector2.zero;


    }

    internal void ExitZone()
    {
        ExitFromSaveZone?.Invoke();
    }

    internal void EnterZone(SaveZone saveZone)
    {
        EnterInSaveZone?.Invoke(saveZone);
    }
}
