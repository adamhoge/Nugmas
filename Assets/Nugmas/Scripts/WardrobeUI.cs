using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeUI : MonoBehaviour
{
    private ItemType _currentItemType;

    [SerializeField]
    private Outfit _nugOutfit;

    [SerializeField]
    public Button _eyesButton;

    [SerializeField]
    public Button _mouthButton;

    [SerializeField]
    public Button _hatButton;

    [SerializeField]
    public Button _bodyButton;

    [SerializeField]
    public RectTransform _itemContentArea;

    [SerializeField]
    public Button _itemButtonPrefab;

    void Start()
    {
        _eyesButton.onClick.AddListener(() => OnItemTypeButtonClicked(ItemType.Eyes));
        _mouthButton.onClick.AddListener(() => OnItemTypeButtonClicked(ItemType.Mouth));
        _hatButton.onClick.AddListener(() => OnItemTypeButtonClicked(ItemType.Hat));
        _bodyButton.onClick.AddListener(() => OnItemTypeButtonClicked(ItemType.Body));

        OnItemTypeButtonClicked(ItemType.Eyes);
    }

    private void OnItemTypeButtonClicked(ItemType itemType)
    {
        _currentItemType = itemType;
        _eyesButton.interactable = itemType != ItemType.Eyes;
        _mouthButton.interactable = itemType != ItemType.Mouth;
        _hatButton.interactable = itemType != ItemType.Hat;
        _bodyButton.interactable = itemType != ItemType.Body;

        RefreshItemButtons();
    }

    private void RefreshItemButtons()
    {
        foreach (Transform child in _itemContentArea)
        {
            Destroy(child.gameObject);
        }

        var items = StuffManager.OwnedItems.Where(item => item.ItemType == _currentItemType);

        foreach (var item in items)
        {
            var itemButtonObj = Instantiate(_itemButtonPrefab, _itemContentArea.transform);
            var itemButton = itemButtonObj.GetComponent<ItemButton>();
            itemButton.ItemData = item;

            itemButtonObj.onClick.AddListener(() =>
            {
                _nugOutfit.Wear(item);
            });
        }
    }
}
