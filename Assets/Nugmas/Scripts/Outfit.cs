using System.Linq;
using UnityEngine;

public class Outfit : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _eyesSpriteRenderer;

    [SerializeField]
    private SpriteRenderer _mouthSpriteRenderer;

    [SerializeField]
    private SpriteRenderer _hatSpriteRenderer;

    [SerializeField]
    private SpriteRenderer _bodySpriteRenderer;

    private ItemData _currentEyes;
    private ItemData _currentMouth;
    private ItemData _currentHat;
    private ItemData _currentBody;

    void Start()
    {
        LoadOutfit();
    }

    public void Wear(ItemData itemData)
    {
        switch (itemData.ItemType)
        {
            case ItemType.Eyes:
                _currentEyes = itemData;
                _eyesSpriteRenderer.sprite = itemData.Sprite;
                break;
            case ItemType.Mouth:
                _currentMouth = itemData;
                _mouthSpriteRenderer.sprite = itemData.Sprite;
                break;
            case ItemType.Hat:
                _currentHat = itemData;
                _hatSpriteRenderer.sprite = itemData.Sprite;
                break;
            case ItemType.Body:
                _currentBody = itemData;
                _bodySpriteRenderer.sprite = itemData.Sprite;
                break;
        }

        SaveOutfit();
    }

    // The items below would usually be implemented outside of this
    // class to keep concerns separate, but this is easier.

    private void SaveOutfit()
    {
        if (_currentEyes != null)
        {
            PlayerPrefs.SetString("EyesItemId", _currentEyes.Id);
        }
        if (_currentMouth != null)
        {
            PlayerPrefs.SetString("MouthItemId", _currentMouth.Id);
        }
        if (_currentHat != null)
        {
            PlayerPrefs.SetString("HatItemId", _currentHat.Id);
        }
        if (_currentBody != null)
        {
            PlayerPrefs.SetString("BodyItemId", _currentBody.Id);
        }
    }

    private void LoadOutfit()
    {
        string eyesItemId = PlayerPrefs.GetString(
            "EyesItemId",
            "f562ed7b-c6ca-450f-a198-0601b8d61e98"
        );
        var itemData = StuffManager.Items.First(i => i.Id == eyesItemId);
        Wear(itemData);

        string mouthItemId = PlayerPrefs.GetString(
            "MouthItemId",
            "ccc8c932-62d8-45f2-b643-63ff2c9cab41"
        );
        itemData = StuffManager.Items.Find(i => i.Id == mouthItemId);
        Wear(itemData);

        string hatItemId = PlayerPrefs.GetString("HatItemId", string.Empty);
        if (!string.IsNullOrEmpty(hatItemId))
        {
            itemData = StuffManager.Items.Find(i => i.Id == hatItemId);
            Wear(itemData);
        }

        string bodyItemId = PlayerPrefs.GetString("BodyItemId", string.Empty);
        if (!string.IsNullOrEmpty(bodyItemId))
        {
            itemData = StuffManager.Items.Find(i => i.Id == bodyItemId);
            Wear(itemData);
        }
    }
}
