using UnityEngine;

public class WardrobeUser : MonoBehaviour
{
    public delegate void StartedUsingWardrobe();
    public delegate void StoppedUsingWardrobe();

    public event StartedUsingWardrobe OnStartedUsingWardrobe;
    public event StoppedUsingWardrobe OnStoppedUsingWardrobe;

    public bool CanUseWardrobe => _canUserWardrobe;

    private bool _canUserWardrobe = false;
    private bool _isUsingWardrobe = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wardrobe"))
        {
            _canUserWardrobe = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wardrobe"))
        {
            if (_isUsingWardrobe)
            {
                StopUsingWardrobe();
            }

            _canUserWardrobe = false;
        }
    }

    public void UseWardrobe()
    {
        if (!_canUserWardrobe || _isUsingWardrobe)
        {
            return;
        }

        _isUsingWardrobe = true;

        OnStartedUsingWardrobe?.Invoke();
    }

    public void StopUsingWardrobe()
    {
        _isUsingWardrobe = false;

        OnStoppedUsingWardrobe?.Invoke();
    }
}
