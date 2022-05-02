using UnityEngine;

[CreateAssetMenu(fileName = "SpriteBean", menuName = "ScriptableObject/SpriteBean")]
public class SpriteBean : ScriptableObject
{
    [SerializeField] private Sprite[] _sprites;

    public Sprite this[int index]=> _sprites[index];
}
