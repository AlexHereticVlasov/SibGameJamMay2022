using UnityEngine;

public abstract class AbstractInventory : MonoBehaviour, IInventory
{
    [System.Serializable]
    public struct InitialItem
    {
        public ItemData ItemData;
        public int Amount;
    }

    [SerializeField] private InitialItem[] _initialItems;

    public IInventoryStorage Storage { get; private set; } = new InventoryStorage();

    private void Awake()
    {
        foreach (var item in _initialItems)
        {
            if (item.Amount <= 0)
                Debug.LogWarning($"{item.ItemData} amount must be positive");
            else
                Storage.Add(item.ItemData, item.Amount);
        }
    }
}
