using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Collectable : AbstractInventory, ICollectable
{
    public void Collect(IInventoryStorage otherStorage)
    {
        foreach (var item in Storage.Items)
            otherStorage.Add(item.ItemData, item.Amount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            //Collect(player.Inventory.Storage);
            Remove();
        }
    }

    private void Remove()
    {
        //ToDo: Add Particles sounds and etc...
        Destroy(gameObject);
    }
}
