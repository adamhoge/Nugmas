using UnityEngine;

public class InsideSceneUI : MonoBehaviour
{
    [SerializeField]
    private Nug _nug;

    [SerializeField]
    private GameObject _useDoorPrompt;

    [SerializeField]
    private GameObject _useWardrobePrompt;

    [SerializeField]
    private GameObject _wardrobeUI;

    void Start()
    {
        _wardrobeUI.SetActive(false);

        _nug.MyWardrobeUser.OnStartedUsingWardrobe += () =>
        {
            _wardrobeUI?.SetActive(true);
        };

        _nug.MyWardrobeUser.OnStoppedUsingWardrobe += () =>
        {
            _wardrobeUI?.SetActive(false);
        };
    }

    void Update()
    {
        _useDoorPrompt.SetActive(_nug != null && _nug.MyDoorUser.CanUseDoor);
        _useWardrobePrompt.SetActive(_nug != null && _nug.MyWardrobeUser.CanUseWardrobe);
    }
}
