using UnityEngine;
using UnityEngine.InputSystem;

public class NugController : MonoBehaviour
{
    [SerializeField]
    private Nug _nug;

    [SerializeField]
    private PlayerInput _playerInput;

    private InputAction _interactAction;
    private InputAction _moveAction;

    private void Start()
    {
        _interactAction = _playerInput.actions.FindAction("Interact");
        _moveAction = _playerInput.actions.FindAction("Move");
    }

    protected void Update()
    {
        UpdateDoorUsage();
        UpdateWardrobeUsage();
        UpdateMovement();
    }

    private void UpdateDoorUsage()
    {
        if (_interactAction.triggered)
        {
            _nug.MyDoorUser.UseDoor();
        }
    }

    private void UpdateWardrobeUsage()
    {
        if (_interactAction.triggered)
        {
            _nug.MyWardrobeUser.UseWardrobe();
        }
    }

    private void UpdateMovement()
    {
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        if (moveInput.x > 0)
        {
            _nug.MoveRight();
        }
        else if (moveInput.x < 0)
        {
            _nug.MoveLeft();
        }
    }
}
