using UnityEngine;

public class InsideSceneUI : MonoBehaviour
{
    [SerializeField]
    private DoorUser _nugDoorUser;

    [SerializeField]
    private GameObject _useDoorPrompt;

    private void Update()
    {
        _useDoorPrompt.SetActive(_nugDoorUser != null && _nugDoorUser.CanUseDoor);
    }
}
