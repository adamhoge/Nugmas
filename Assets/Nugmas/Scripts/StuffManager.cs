using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StuffManager : MonoBehaviour
{
    private static StuffManager _instance;

    public static List<ItemData> Items => _instance._items;

    public static List<ItemData> OwnedItems => _instance._ownedItems;

    [SerializeField]
    private List<ItemData> _items;

    [SerializeField]
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

    public static ItemData AddItem(ItemData item)
    {
        if (HasItem(item))
        {
            return item;
        }
        _instance._ownedItems.Add(item);
        return item;
    }

    public static ItemData AddRandomItem() { 
        var unownedItems = _instance._items.Where(i => !HasItem(i)).ToList();
        Debug.Log("unowned count: " + unownedItems.Count);
        if(unownedItems.Count > 0) {
            int index = Random.Range(0,unownedItems.Count); 
            Debug.Log("index: " + index);
            return AddItem(unownedItems[index]);
        }
        return null;
    }
}
