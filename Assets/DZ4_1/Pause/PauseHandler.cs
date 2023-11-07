using System;
using System.Collections.Generic;

public class PauseHandler : IPause, IDisposable
{
    private PlayerInput _playerInput;
    private List<IPause> _handlers = new List<IPause>();

    private PauseHandler(PlayerInput playerInput)
    {
        _playerInput = playerInput;
        _playerInput.PausePressed += OnPausePressed;
        _playerInput.PauseUnpressed += OnPauseUnpressed;
    }

    public void Add(IPause handler) => _handlers.Add(handler); 
    public void Remove(IPause handler) => _handlers.Remove(handler);

    public void SetPause(bool isPaused)
    {
        foreach (var handler in _handlers)
            handler.SetPause(isPaused);
    }

    public void Dispose()
    {
        _playerInput.PausePressed -= OnPausePressed;
        _playerInput.PauseUnpressed -= OnPauseUnpressed;
    }

    private void OnPausePressed() => SetPause(true);
    private void OnPauseUnpressed() => SetPause(false);
}
