public struct InventoryStorageItem
{
    public ItemData ItemData;
    public int Amount;

    public InventoryStorageItem(ItemData itemData, int amount)
    {
        ItemData = itemData;
        Amount = amount;
    }
}
