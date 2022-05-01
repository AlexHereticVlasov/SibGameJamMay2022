using UnityEngine;
using UnityEngine.Events;

public class Nexus : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isRepeared;

    public event UnityAction Interacted;

    public bool IsRepeared => _isRepeared;

    public void Interact()
    {
        if (_isRepeared == false)
        {
            Interacted?.Invoke();
            _isRepeared = true;
            //ToDo: Edit Viev
        }
    }
}
