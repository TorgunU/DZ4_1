using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public abstract class PlayerInput : MonoBehaviour, IPauseEvents
{
    protected InputActions Actions;

    public abstract event Action PausePressed;
    public abstract event Action PauseUnpressed;

    [Inject]
    private void Construct(InputActions actions)
    {
        Actions = actions;
        Init();
    }

    private void Init()
    {
        Actions.Dekstop.Pause.performed += pauseContext =>
        RaisePausePressed(pauseContext);
        Actions.Dekstop.Pause.performed += pauseContext =>
        RaisePauseUnpressed(pauseContext);
    }

    protected virtual void OnEnable()
    {
        Actions.Enable();
    }

    protected virtual void OnDisable()
    {
        Actions.Disable();
    }

    protected abstract void RaisePausePressed(InputAction.CallbackContext attackContext);
    protected abstract void RaisePauseUnpressed(InputAction.CallbackContext movementcontext);
}