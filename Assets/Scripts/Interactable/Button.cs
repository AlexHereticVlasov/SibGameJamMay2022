using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField] private Nexus _nexus;
    private bool _wasPreased;

    public event UnityAction Interacted;

    public void Interact(AbstractInventory inventory)
    {
        //ToDo: Animate
        if (_nexus != null && _nexus.IsRepeared)
        {
            _wasPreased = true;
            Interacted?.Invoke();
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
