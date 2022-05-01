using UnityEngine;

public abstract class State
{
    protected Player Player;
    protected Checks Checks;
    protected Animator Animator;
    protected PlayerStateMachine StateMachine;
    protected PlayerConfig Config;
    protected int Hash;
    protected float StartTime;
    protected bool IsAnimationFinished;
    protected bool IsExitingState;
    protected bool IsOnGround;
    protected int XInput;
    protected bool JumpInput;
    private bool _isInteract;

    public State(Checks checks, Animator animator,Player player,  PlayerStateMachine stateMachine, string animationName, PlayerConfig config)
    {
        Player = player;
        Checks = checks;
        Animator = animator;
        StateMachine = stateMachine;
        Hash = Animator.StringToHash(animationName);
        Config = config;
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

        if (_isInteract)
        {
            if (Checks.TryInteract(out IInteractable interactable))
            {
                if (IsOnGround)
                {
                    Player.OnEarthInteractState.SetInteractable(interactable);
                    StateMachine.Transite(Player.OnEarthInteractState);
                }
                else
                {
                    Player.InAirInteractionState.SetInteractable(interactable);
                    StateMachine.Transite(Player.InAirInteractionState);
                }
            }
        }
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
        _isInteract = Checks.IsInteract();
    }

}

