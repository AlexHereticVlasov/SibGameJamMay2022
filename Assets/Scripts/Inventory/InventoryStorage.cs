using System.Collections.Generic;
using UnityEngine.Events;

public class InventoryStorage : IInventoryStorage
{

    public class Comparer : IComparer<ItemData>
    {
        public static readonly Comparer Instance = new Comparer();

        public int Compare(ItemData x, ItemData y)
        {
            if (x.LessThen(y))
                return -1;
            if (y.LessThen(x))
                return 1;

            int instanceIdX = x.GetInstanceID();
            int instanceIdY = y.GetInstanceID();

            if (instanceIdX < instanceIdY)
                return -1;
            if (instanceIdX > instanceIdY)
                return 1;

            return 0;
        }
    }

    private readonly SortedDictionary<ItemData, int> _items = new SortedDictionary<ItemData, int>(Comparer.Instance);

    public IEnumerable<InventoryStorageItem> Items
    {
        get
        {
            foreach (var item in _items)
                yield return new InventoryStorageItem(item.Key, item.Value);
        }
    }

    public event UnityAction Changed;

    public void Add(ItemData item, int amount)
    {
        if (amount <= 0) return;

        _items.TryGetValue(item, out int count);
        _items[item] = amount + count;

        Changed?.Invoke();
    }

    public bool TryRemove(ItemData item, int amount)
    {
        if (amount <= 0)
            return false;

        if (_items.TryGetValue(item, out int count) == false || count < amount)
            return false;

        count -= amount;
        if (count > 0)
            _items[item] = count;
        
        if (_items.Remove(item) == false)
            return false;

        Changed?.Invoke();
        return true;
    }

    public void Clear()
    {
        _items.Clear();
        Changed?.Invoke();
    }

    public int CountOf(ItemData item)
    {
        _items.TryGetValue(item, out int count);
        return count;
    }
}
