using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideScene : MonoBehaviour
{
    [SerializeField]
    public DoorUser _nugDoorUser;

    private void Start()
    {
        _nugDoorUser.OnUsedDoor += HandleNugUsedDoor;
    }

    private void HandleNugUsedDoor()
    {
        SceneManager.LoadScene(GameConstants.OutsideSceneName);
    }
}
