using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Nugmas/Item Data")]
public class ItemData : ScriptableObject
{
    [ObjectId]
    public string Id;
    public string Name;
    public ItemType ItemType;
    public Sprite Sprite;
}
