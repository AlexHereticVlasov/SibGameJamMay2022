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

