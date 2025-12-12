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

    public void Wear(ItemData itemData)
    {
        switch (itemData.ItemType)
        {
            case ItemType.Eyes:
                _eyesSpriteRenderer.sprite = itemData.Sprite;
                break;
            case ItemType.Mouth:
                _mouthSpriteRenderer.sprite = itemData.Sprite;
                break;
            case ItemType.Hat:
                _hatSpriteRenderer.sprite = itemData.Sprite;
                break;
            case ItemType.Body:
                _bodySpriteRenderer.sprite = itemData.Sprite;
                break;
        }
    }
}
