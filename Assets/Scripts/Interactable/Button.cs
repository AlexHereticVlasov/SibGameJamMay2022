using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ButtonState { NoEnergy, HasEnergy, Presed}

public abstract class BaseActivalible : MonoBehaviour
{
    public abstract bool TryActivate();
    public abstract void Activate();
}

public class Button : BaseActivalible, IInteractable
{
    //energy
    //noenerge
    //presed
    [SerializeField] private ButtonState _state;
    [SerializeField] private BaseActivalible _next;
    //2 energy line

    public event UnityAction Interacted;

    public override void Activate()
    {
        
    }

    public void Interact()
    {
        if (_state == ButtonState.HasEnergy)
        {
            //ToDo: ActivateTarget
            if (_next.TryActivate())
            { 
                _state = ButtonState.Presed;
            }
        }
    }

    public override bool TryActivate()
    {
        _state = ButtonState.HasEnergy;
        return true;
    }
}

