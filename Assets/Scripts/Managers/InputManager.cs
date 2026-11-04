using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public static InputManager I { get; private set; }

    private InputSystem_Actions inputActions;

    public event Action OnLClickStart;
    public event Action OnLClickEnd;

    public Vector2 MousePos => Mouse.current.position.ReadValue();

    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }

        I = this;

        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();

        inputActions.Gameplay.LClick.started += HandleLClickStart;
        inputActions.Gameplay.LClick.canceled += HandleLClickEnd;
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();

        inputActions.Gameplay.LClick.started -= HandleLClickStart;
        inputActions.Gameplay.LClick.canceled -= HandleLClickEnd;
    }

    private void HandleLClickStart(InputAction.CallbackContext context)
    {
        OnLClickStart?.Invoke();
    }

    private void HandleLClickEnd(InputAction.CallbackContext context)
    {
        OnLClickEnd?.Invoke();
    }
}
