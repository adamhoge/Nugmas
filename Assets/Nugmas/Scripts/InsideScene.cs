using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideScene : MonoBehaviour
{
    public float UnzoomedOrthographicSize = 6.0f;
    public Vector2 UnzoomedCameraPosition = new(0f, 3f);
    public float ZoomedOrthographicSize = 2.0f;
    public Vector2 ZoomedCameraOffset = new(3.0f, 1.0f);

    [SerializeField]
    private Nug _nug;

    [SerializeField]
    private Camera _camera;

    public void ToggleMusic()
    {
        MusicManager.Instance.ToggleMusic();
    }

    private void Start()
    {
        _nug.MyDoorUser.OnUsedDoor += HandleNugUsedDoor;
        _nug.MyWardrobeUser.OnStartedUsingWardrobe += HandleNugStartedUsingWardrobe;
        _nug.MyWardrobeUser.OnStoppedUsingWardrobe += HandleNugStoppedUsingWardrobe;
    }

    private void HandleNugUsedDoor()
    {
        SceneManager.LoadScene(GameConstants.OutsideSceneName);
    }

    private void HandleNugStartedUsingWardrobe()
    {
        _camera.orthographicSize = ZoomedOrthographicSize;
        _camera.transform.position = new Vector3(
            _nug.transform.position.x + ZoomedCameraOffset.x,
            ZoomedCameraOffset.y,
            _camera.transform.position.z
        );

        _nug.MyRigidbody2D.linearVelocity = new Vector2(0.0f, _nug.MyRigidbody2D.linearVelocity.y);
    }

    private void HandleNugStoppedUsingWardrobe()
    {
        _camera.orthographicSize = UnzoomedOrthographicSize;
        _camera.transform.position = new Vector3(
            UnzoomedCameraPosition.x,
            UnzoomedCameraPosition.y,
            _camera.transform.position.z
        );
    }
}
