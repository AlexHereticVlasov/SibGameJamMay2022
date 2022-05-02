using UnityEngine;
using UnityEngine.Events;

public enum NexusState {Broken, TurnedOff, TurnedOn }

public class Nexus : MonoBehaviour, IInteractable
{
    [SerializeField] private NexusState _state;
    [SerializeField] private BaseActivalible[] _targets;

    public event UnityAction Interacted;

    public void Interact()
    {
        if (_state == NexusState.Broken)
        {
            Interacted?.Invoke();
            _state = NexusState.TurnedOn;
            //ToDo: Edit Viev
            ActivateTargets();
        }
        else if (_state == NexusState.TurnedOff)
        {
            _state = NexusState.TurnedOn;
            ActivateTargets();
        }
    }

    private void ActivateTargets()
    {
        foreach (var target in _targets)
        {
            target.TryActivate();
        }
    }
}
