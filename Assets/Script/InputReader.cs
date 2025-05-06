using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, InputSystem.IControllerActions
{
    private InputSystem inputSystem;
    private Vector2 movement;
    public Vector2 Movemenet
    {
        get
        {
            return movement;
        }
        set
        {
            movement = value;
        }
    }
    public event System.Action OnJumpEvent;

    void Start()
    {
        inputSystem = new InputSystem();
        inputSystem.Controller.SetCallbacks(this);
        inputSystem.Controller.Enable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpEvent?.Invoke();
        }
    }
}
