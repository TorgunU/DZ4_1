using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private PauseHandler _pauseHandler;

    [Inject]
    private void Construct(PauseHandler pauseHandler)
    {
        _pauseHandler = pauseHandler;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            _pauseHandler.SetPause(true);

        if(Input.GetKeyDown(KeyCode.S))
            _pauseHandler.SetPause(false);
    }
}
