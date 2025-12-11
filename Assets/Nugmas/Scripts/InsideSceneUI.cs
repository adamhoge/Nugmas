using UnityEngine;

public class InsideSceneUI : MonoBehaviour
{
    [SerializeField]
    private Nug _nug;

    [SerializeField]
    private GameObject _useDoorPrompt;

    [SerializeField]
    private GameObject _useWardrobePrompt;

    private void Update()
    {
        _useDoorPrompt.SetActive(_nug != null && _nug.MyDoorUser.CanUseDoor);
        _useWardrobePrompt.SetActive(_nug != null && _nug.MyWardrobeUser.CanUseWardrobe);
    }
}
