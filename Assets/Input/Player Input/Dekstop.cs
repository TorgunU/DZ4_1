using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dekstop : PlayerInput
{
    public override event Action PausePressed;
    public override event Action PauseUnpressed;

    protected override void RaisePausePressed(InputAction.CallbackContext pauseContext)
    {
        if (pauseContext.performed)
        {
            PausePressed?.Invoke();
        }
    }

    protected override void RaisePauseUnpressed(InputAction.CallbackContext pauseContext)
    {
        if (pauseContext.performed)
        {
            PauseUnpressed?.Invoke();
        }
    }
}
