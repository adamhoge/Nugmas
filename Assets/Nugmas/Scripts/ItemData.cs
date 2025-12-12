using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Nugmas/Item Data")]
public class ItemData : ScriptableObject
{
    public string Name;
    public ItemType ItemType;
    public Sprite Sprite;
}
