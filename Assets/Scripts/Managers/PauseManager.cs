using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : Singleton<PauseManager>
{
    private bool _paused;

    public delegate void OnPause();
    public OnPause Paused;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        _paused = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void TogglePause() 
    {
        _paused = !_paused;
        Paused();
    }

    public bool GetPaused()
    {
        return _paused;
    }
}
