using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public static InputManager I { get; private set; }

    private InputSystem_Actions inputActions;

    public event Action OnLClickStarted;
    public event Action OnLClickEnded;

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

        inputActions.Gameplay.LClick.started += HandleLClickStarted;
        inputActions.Gameplay.LClick.canceled += HandleLClickEnded;
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();

        inputActions.Gameplay.LClick.started -= HandleLClickStarted;
        inputActions.Gameplay.LClick.canceled -= HandleLClickEnded;
    }

    private void HandleLClickStarted(InputAction.CallbackContext context)
    {
        OnLClickStarted?.Invoke();
    }

    private void HandleLClickEnded(InputAction.CallbackContext context)
    {
        OnLClickEnded?.Invoke();
    }
}
