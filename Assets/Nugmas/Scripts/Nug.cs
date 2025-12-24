using System;
using Unity.Mathematics;
using UnityEngine;

public class Nug : MonoBehaviour
{
    public Outfit MyOutfit => _myOutfit;
    public float jumpPower = 10.0f;
    public float accelerationPower = 0.1f;
    private bool grounded = true;

    public Rigidbody2D MyRigidbody2D => _myRigidbody2D;
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

    public void TryJump()
    {
        Debug.Log("grounded: " + grounded.ToString());
        if (grounded)
        {
            grounded = false;
            _myRigidbody2D.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private float IncreaseSpeed(float inputSpeed = 0, string direction = "right")
    {
        float maxSpeed = 10f;
        float outputSpeed = inputSpeed;
        if (direction == "right")
        {
            outputSpeed = Math.Min(maxSpeed, inputSpeed + accelerationPower);
        }
        else
        {
            outputSpeed = Math.Max(-maxSpeed, inputSpeed - accelerationPower);
        }
        return outputSpeed;
    }

    public void MoveRight()
    {
        //gameObject.transform.localScale = new Vector3(-1,1,1);
        _myRigidbody2D.linearVelocity = new Vector2(
            IncreaseSpeed(_myRigidbody2D.linearVelocityX),
            _myRigidbody2D.linearVelocityY
        );
    }

    public void MoveLeft()
    {
        //gameObject.transform.localScale = new Vector3(1,1,1);
        _myRigidbody2D.linearVelocity = new Vector2(
            IncreaseSpeed(_myRigidbody2D.linearVelocityX, "left"),
            _myRigidbody2D.linearVelocityY
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Ground" && !grounded)
        {
            Debug.Log("touchdown");
            grounded = true;
        }
    }
}
