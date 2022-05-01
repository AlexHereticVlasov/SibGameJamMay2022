using System.Collections.Generic;
using UnityEngine.Events;

public interface IInventoryStorage
{
    event UnityAction Changed;

    IEnumerable<InventoryStorageItem> Items { get; }

    int CountOf(ItemData item);
    void Add(ItemData item, int amount);
    bool TryRemove(ItemData item, int amount);
    void Clear();
}
