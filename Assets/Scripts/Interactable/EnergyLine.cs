using UnityEngine;
using UnityEngine.Events;

public class EnergyLine : MonoBehaviour, IInteractable
{
    public event UnityAction Interacted;

    private bool _isRepeared;

    public bool IsRepeared => _isRepeared;

    public void Interact(AbstractInventory inventory)
    {
        Interacted?.Invoke();
    }
}
