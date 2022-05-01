using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private AbstractInventory _inventory;

    public event UnityAction Dead;

    public AbstractInventory Inventory => _inventory;

    internal void Die()
    {
        Dead?.Invoke();
    }
}
