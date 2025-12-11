using UnityEngine;

public class Nug : MonoBehaviour
{
    public Outfit MyOutfit => _myOutfit;

    public DoorUser MyDoorUser => _myDoorUser;

    public WardrobeUser MyWardrobeUser => _myWardrobeUser;

    [SerializeField]
    private Rigidbody2D _myRigidbody2D;

    [SerializeField]
    private Outfit _myOutfit;

    [SerializeField]
    private DoorUser _myDoorUser;

    [SerializeField]
    private WardrobeUser _myWardrobeUser;

    public void MoveRight()
    {
        _myRigidbody2D.linearVelocity = Vector2.right * 5f;
    }

    public void MoveLeft()
    {
        _myRigidbody2D.linearVelocity = Vector2.left * 5f;
    }
}
