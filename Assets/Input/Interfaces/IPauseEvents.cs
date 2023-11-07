using System;

public interface IPauseEvents
{
    event Action PausePressed;
    event Action PauseUnpressed;
}
