﻿using Assets.Scripts.Services.ServiceLocatorSystem;
using System.Collections.Generic;


public class PauseManager : IPauseHandler, IService
{
    private readonly List<IPauseHandler> _pauseHandlers = new List<IPauseHandler>();

    public bool IsPaused { get; private set; }

    public void Register(IPauseHandler pauseHandler)
    {
        _pauseHandlers.Add(pauseHandler);
    }

    public void UnRegister(IPauseHandler pauseHandler)
    {
        _pauseHandlers.Remove(pauseHandler);
    }

    public void SetPaused(bool isPaused)
    {
        IsPaused = isPaused;    

        foreach (var handler in _pauseHandlers)
        {
            handler.SetPaused(isPaused);
        }
    }
}

