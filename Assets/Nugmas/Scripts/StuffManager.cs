using UnityEngine;

public class StuffManager : MonoBehaviour
{
    private static StuffManager _instance;

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
        Debug.Log("Not implemented yet: StuffManager.HasItem");

        return false;
    }

    public static void AddItem(ItemData item)
    {
        Debug.Log("Not implemented yet: StuffManager.AddItem");
    }

    public static void AddRandomItem()
    {
        Debug.Log("Not implemented yet: StuffManager.AddRandomItem");
    }
}
