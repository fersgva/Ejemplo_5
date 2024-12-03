using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputManager")]
public class InputManagerSO : ScriptableObject
{
    private Inputs inputs;

    public event Action<Vector2> OnMoverStarted;
    public event Action OnMoverCanceled;
    public event Action OnCorrerStarted;
    public event Action OnCorrerCanceled;

    private void OnEnable()
    {
        inputs = new Inputs();
        inputs.Enable();
        inputs.Gameplay.Mover.performed += MoverStarted;
        inputs.Gameplay.Mover.canceled += MoverCanceled;
        inputs.Gameplay.Correr.started += CorrerStarted;
        inputs.Gameplay.Correr.canceled += CorrerCanceled;


    }

    private void CorrerStarted(InputAction.CallbackContext obj)
    {
        OnCorrerStarted?.Invoke();
    }
    private void CorrerCanceled(InputAction.CallbackContext obj)
    {
        OnCorrerCanceled?.Invoke();
    }

    private void MoverStarted(InputAction.CallbackContext ctx)
    {
        OnMoverStarted?.Invoke(ctx.ReadValue<Vector2>());
    }
    private void MoverCanceled(InputAction.CallbackContext ctx)
    {
        OnMoverCanceled?.Invoke();
    }

}
