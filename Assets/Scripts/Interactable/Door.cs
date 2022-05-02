using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum DoorState { Locked, Closed, Open}

public class Door : BaseActivalible
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private int _originNeed = 1;
    private DoorState _state = DoorState.Locked;
    private int _currentOrigins = 0;

    public event UnityAction Victory;
    public event UnityAction<DoorState> StateChanged;

    private void Start()
    {
        StateChanged?.Invoke(_state);
    }

    public override void Activate()
    {
       
        Debug.Log($"{this} Activated");
        StartCoroutine(Open());
    }

    public override bool TryActivate()
    {
        _currentOrigins++;

        if (_currentOrigins == _originNeed)
        {
            Activate();
        }

        return true;
    }

    private IEnumerator Open()
    {
        _state = DoorState.Closed;
        StateChanged?.Invoke(_state);
        //_animator.SetTrigger("Open");
        yield return new WaitForSeconds(1); //Anim Length;
        _boxCollider.enabled = true;
        _state = DoorState.Open;
        StateChanged?.Invoke(_state);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Victory?.Invoke();   
        }
    }
}

