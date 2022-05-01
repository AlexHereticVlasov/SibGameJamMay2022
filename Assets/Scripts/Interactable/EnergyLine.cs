using UnityEngine;
using UnityEngine.Events;

public class EnergyLine : MonoBehaviour, IInteractable
{
    //3states
    public event UnityAction Interacted;

    private bool _isRepeared;

    public bool IsRepeared => _isRepeared;

    public void Interact()
    {
        Interacted?.Invoke();
    }
}

public class Segment : MonoBehaviour
{ 

}
