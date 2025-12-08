using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideScene : MonoBehaviour
{
    public Vector2 NugStartingPosition = Vector2.zero;

    [SerializeField]
    public Nug _nug;

    private static bool _isFirstLoad = true;

    private void Start()
    {
        _nug.MyDoorUser.OnUsedDoor += HandleNugUsedDoor;

        if (_isFirstLoad)
        {
            _nug.transform.position = NugStartingPosition;
            _isFirstLoad = false;
            return;
        }
    }

    private void HandleNugUsedDoor()
    {
        SceneManager.LoadScene(GameConstants.InsideSceneName);
    }
}
