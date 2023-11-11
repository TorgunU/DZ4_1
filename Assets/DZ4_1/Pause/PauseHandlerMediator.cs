using UnityEngine;
using Zenject;

public class PauseHandlerMediator : MonoBehaviour
{
    private PlayerInput _input;
    private PauseHandler _pauseHandler;

    [Inject]
    private void Construct(PlayerInput input, PauseHandler pauseHandler)
    {
        _input = input;
        _pauseHandler = pauseHandler;

        _input.PausePressed += OnPausePressed;
        _input.PauseUnpressed += OnPauseUnpressed;
    }

    private void OnDisable()
    {
        _input.PausePressed -= OnPausePressed;
        _input.PauseUnpressed -= OnPauseUnpressed;
    }

    private void OnPausePressed()
    {
        _pauseHandler.SetPause(true);
    }

    private void OnPauseUnpressed()
    {
        _pauseHandler.SetPause(false);
    }
}
