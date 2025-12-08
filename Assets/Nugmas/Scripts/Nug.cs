using UnityEngine;

public class Nug : MonoBehaviour
{
    public DoorUser MyDoorUser => _myDoorUser;

    [SerializeField]
    private Rigidbody2D _myRigidbody2D;

    [SerializeField]
    private DoorUser _myDoorUser;

    public void MoveRight()
    {
        _myRigidbody2D.linearVelocity = Vector2.right * 5f;
    }

    public void MoveLeft()
    {
        _myRigidbody2D.linearVelocity = Vector2.left * 5f;
    }
}
