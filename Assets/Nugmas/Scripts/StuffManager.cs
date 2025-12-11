using System.Collections.Generic;
using UnityEngine;

public class StuffManager : MonoBehaviour
{
    private static StuffManager _instance;

    public static List<ItemData> Items => _instance._items;

    public static List<ItemData> OwnedItems => _instance._ownedItems;

    [SerializeField]
    private List<ItemData> _items;

    private List<ItemData> _ownedItems = new();

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static bool HasItem(ItemData item)
    {
        return _instance._ownedItems.Contains(item);
    }

    public static void AddItem(ItemData item)
    {
        if (HasItem(item))
        {
            return;
        }

        _instance._ownedItems.Add(item);
    }

    public static void AddRandomItem() { }
}
