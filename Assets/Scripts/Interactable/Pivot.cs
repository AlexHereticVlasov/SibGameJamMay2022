using UnityEngine;
using UnityEngine.Events;

public class Pivot : MonoBehaviour, IInteractable
{
    public event UnityAction Interacted;

    public void Interact(AbstractInventory inventory)
    {
        //ToDo: Play Animation 
        Interacted?.Invoke();
    }
}
