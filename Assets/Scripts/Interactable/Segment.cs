using UnityEngine;
using UnityEngine.Events;

public class Segment : MonoBehaviour, IInteractable
{
    [SerializeField] private SegmentState _state;
    [SerializeField] private Collider2D _collider;

    public event UnityAction Interacted;

    public SegmentState State => _state;
    public void Interact()
    {
        if (_state == SegmentState.Broken)
        {
            _state = SegmentState.NoEnergy;
            _collider.enabled = false;
            Interacted?.Invoke();
        }
    }
}
