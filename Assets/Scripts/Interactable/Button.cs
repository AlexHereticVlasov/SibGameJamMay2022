using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractable
{
    //energy
    //noenerge
    //presed

    //2 energy line

    [SerializeField] private Nexus _nexus;
    private bool _wasPreased;

    public event UnityAction Interacted;

    public void Interact()
    {
        //ToDo: Animate
        if (_nexus != null && _nexus.IsRepeared)
        {
            _wasPreased = true;
            Interacted?.Invoke();
            Debug.Log("Interact");
        }
    }
}

[System.Serializable]
public class ActivationCondition
{
    [SerializeField] private List<EnergyLine> _lines;

    public bool isActive()
    {
        foreach (var line in _lines)
            if (line.IsRepeared == false)
                return false;

        return true;
    }
}
public class Door : MonoBehaviour
{

    //1 energy line
    [SerializeField] private ActivationCondition _condition;
    [SerializeField] private bool _isOpen;


    public void Open()
    {
        if (_isOpen) return;

        if (_condition.isActive())
        {
            _isOpen = true;
            //Play Aniimation, disable Collider
        }
    }
}

//enother door
//3 energy line max
