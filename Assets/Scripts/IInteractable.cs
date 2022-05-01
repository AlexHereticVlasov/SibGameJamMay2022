using UnityEngine.Events;

public interface IInteractable
{
    public event UnityAction Interacted;

    void Interact();
}
