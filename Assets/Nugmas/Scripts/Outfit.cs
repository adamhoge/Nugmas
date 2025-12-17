using System;
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

    public void Wear(ItemData itemData, bool save = true)
    {
        switch (itemData.ItemType)
        {
            case ItemType.Eyes:
                _currentEyes = itemData;
                _eyesSpriteRenderer.sprite = itemData != null ? itemData.Sprite : null;
                break;
            case ItemType.Mouth:
                _currentMouth = itemData;
                _mouthSpriteRenderer.sprite = itemData != null ? itemData.Sprite : null;
                break;
            case ItemType.Hat:
                _currentHat = itemData;
                _hatSpriteRenderer.sprite = itemData != null ? itemData.Sprite : null;
                break;
            case ItemType.Body:
                _currentBody = itemData;
                _bodySpriteRenderer.sprite = itemData != null ? itemData.Sprite : null;
                break;
        }

        if (save)
        {
            SaveOutfit();
        }
    }

    public void Remove(ItemType itemType, bool save = true)
    {
        switch (itemType)
        {
            case ItemType.Eyes:
                _currentEyes = null;
                _eyesSpriteRenderer.sprite = null;
                break;
            case ItemType.Mouth:
                _currentMouth = null;
                _mouthSpriteRenderer.sprite = null;
                break;
            case ItemType.Hat:
                _currentHat = null;
                _hatSpriteRenderer.sprite = null;
                break;
            case ItemType.Body:
                _currentBody = null;
                _bodySpriteRenderer.sprite = null;
                break;
        }

        if (save)
        {
            SaveOutfit();
        }
    }

    // The items below would usually be implemented outside of this
    // class to keep concerns separate, but this is easier.

    private void SaveOutfit()
    {
        PlayerPrefs.SetString("EyesItemId", _currentEyes != null ? _currentEyes.Id : string.Empty);

        PlayerPrefs.SetString(
            "MouthItemId",
            _currentMouth != null ? _currentMouth.Id : string.Empty
        );

        PlayerPrefs.SetString("HatItemId", _currentHat != null ? _currentHat.Id : string.Empty);

        PlayerPrefs.SetString("BodyItemId", _currentBody != null ? _currentBody.Id : string.Empty);
    }

    private void LoadOutfit()
    {
        if (!PlayerPrefs.HasKey("EyesItemId"))
        {
            PlayerPrefs.SetString("EyesItemId", "f562ed7b-c6ca-450f-a198-0601b8d61e98");
        }

        if (!PlayerPrefs.HasKey("MouthItemId"))
        {
            PlayerPrefs.SetString("MouthItemId", "ccc8c932-62d8-45f2-b643-63ff2c9cab41");
        }

        string eyesItemId = PlayerPrefs.GetString("EyesItemId");
        if (!string.IsNullOrEmpty(eyesItemId))
        {
            var itemData = StuffManager.Items.Find(i => i.Id == eyesItemId);
            Wear(itemData, save: false);
        }
        else
        {
            Remove(ItemType.Eyes, save: false);
        }

        string mouthItemId = PlayerPrefs.GetString("MouthItemId");
        if (!string.IsNullOrEmpty(mouthItemId))
        {
            var itemData = StuffManager.Items.Find(i => i.Id == mouthItemId);
            Wear(itemData, save: false);
        }
        else
        {
            Remove(ItemType.Mouth, save: false);
        }

        string hatItemId = PlayerPrefs.GetString("HatItemId", string.Empty);
        if (!string.IsNullOrEmpty(hatItemId))
        {
            var itemData = StuffManager.Items.Find(i => i.Id == hatItemId);
            Wear(itemData, save: false);
        }
        else
        {
            Remove(ItemType.Hat, save: false);
        }

        string bodyItemId = PlayerPrefs.GetString("BodyItemId", string.Empty);
        if (!string.IsNullOrEmpty(bodyItemId))
        {
            var itemData = StuffManager.Items.Find(i => i.Id == bodyItemId);
            Wear(itemData, save: false);
        }
        else
        {
            Remove(ItemType.Body, save: false);
        }
    }
}
