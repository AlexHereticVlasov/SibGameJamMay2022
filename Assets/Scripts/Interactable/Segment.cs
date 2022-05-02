using System;
using UnityEngine;
using UnityEngine.Events;

public class Segment : MonoBehaviour, IInteractable
{
    [SerializeField] private SegmentState _state;
    [SerializeField] private Collider2D _collider;

    public event UnityAction Interacted;
    public event UnityAction<SegmentState> StateChanged;
    
    public SegmentState State => _state;

    private void Start()
    {
        StateChanged?.Invoke(_state);    
    }

    public void Interact()
    {
        if (_state == SegmentState.Broken)
        {
            _state = SegmentState.Repeared;
            StateChanged?.Invoke(_state);
            _collider.enabled = false;
            Interacted?.Invoke();
        }
    }

    internal void GivePower()
    {
        if (_state == SegmentState.Repeared)
        {
            _state = SegmentState.RepearedAndHasEnergy;
        }
        else if (_state == SegmentState.NoEnergy)
        {
            _state = SegmentState.HasEnergy;
        }
        StateChanged?.Invoke(_state);
    }
}
