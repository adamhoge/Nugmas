using System;
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

    void Start()
        {
            if (PlayerPrefs.HasKey("ownedItems"))
            {
                string[] savedOwnedItems = PlayerPrefs.GetString("ownedItems").Split(";");
                foreach(string itemID in savedOwnedItems)
                {
                    Debug.Log("saved Item ID == " + itemID);
                    AddItem(Items.Find(i => i.Id == itemID));
                }
            }
        }

    public static bool HasItem(ItemData item)
    {
        return _instance._ownedItems.Contains(item);
    }

    public static bool GotEmAll()
    {
         var unownedItems = _instance._items.Where(i => !HasItem(i)).ToList();
         return unownedItems.Count <= 0;
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
            int index = UnityEngine.Random.Range(0,unownedItems.Count); 
            Debug.Log("index: " + index);
            AddItem(unownedItems[index]);
            List<string> currentlyOwnedItems = new List<string>();
            foreach(ItemData thisItem in _instance._ownedItems)
                {
                    Debug.Log("this Item ID == " + thisItem.Id);
                    currentlyOwnedItems.Add(thisItem.Id);
                }
            PlayerPrefs.SetString("ownedItems",String.Join(";",currentlyOwnedItems));
            return unownedItems[index];
        }
        return null;
    }
}
