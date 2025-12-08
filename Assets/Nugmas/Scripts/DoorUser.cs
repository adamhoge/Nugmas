using UnityEngine;

public class DoorUser : MonoBehaviour
{
    public delegate void UsedDoor();

    public event UsedDoor OnUsedDoor;

    public bool CanUseDoor => _canUseDoor;

    private bool _canUseDoor = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            _canUseDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            _canUseDoor = false;
        }
    }

    public void UseDoor()
    {
        if (!_canUseDoor)
        {
            return;
        }

        OnUsedDoor?.Invoke();
    }
}
