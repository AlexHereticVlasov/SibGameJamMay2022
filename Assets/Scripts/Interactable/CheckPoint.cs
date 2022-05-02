using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CheckPointState { Broken, TurnedOff, TurnedOn}

public class CheckPoint : BaseActivalible, IInteractable
{
    [SerializeField] private CheckPointState _state;
    [SerializeField] private SaveZone _saveZone;
    [SerializeField] private BaseActivalible _next;
    //[SerializeField] private bool _isActive;
    [SerializeField] private int _needOrigins;
    //private bool _hasPower;
    private int _currentOrigins;

    public event UnityAction Activated;
    public event UnityAction Interacted;
    public event UnityAction<CheckPointState> StateChanged;

    private void Awake()
    {
        _saveZone.gameObject.SetActive(_state == CheckPointState.TurnedOn);
    }

    private void Start()
    {
        StateChanged?.Invoke(_state);
    }

    public override bool TryActivate()
    {
        _currentOrigins++;
        if (_state == CheckPointState.Broken)
        {
            return false;
        }
        
        if (_currentOrigins == _needOrigins)
        {
            Activate();
            _next.TryActivate();
        }
        return true;
    }

    public override void Activate()
    {
        _state = CheckPointState.TurnedOn;
        StateChanged?.Invoke(_state);
        Activated?.Invoke();
        _saveZone.gameObject.SetActive(true);
        //_isActive = true;
    }

    public void Interact()
    {
        if (_needOrigins == _currentOrigins)
        {
            Activate();
            _next.TryActivate();
        }
        else
        {
            _state = CheckPointState.TurnedOff;
            StateChanged?.Invoke(_state);
        }
    }
}
