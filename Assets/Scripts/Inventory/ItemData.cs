using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/InventoryItem")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _description;

    public string Name => _name;
    public Sprite Sprite => _sprite;
    public string Description => _description;

    public bool LessThen(ItemData other) => _name.CompareTo(other.name) < 0;
}
