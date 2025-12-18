using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public ItemData ItemData
    {
        get => _itemData;
        set => SetItemData(value);
    }

    [SerializeField]
    private Image _itemImage;

    private ItemData _itemData;

    private void SetItemData(ItemData itemData)
    {
        _itemData = itemData;

        if (_itemData != null)
        {
            _itemImage.sprite = _itemData.Sprite;
        }
        else
        {
            _itemImage.gameObject.SetActive(false);
        }
    }
}
