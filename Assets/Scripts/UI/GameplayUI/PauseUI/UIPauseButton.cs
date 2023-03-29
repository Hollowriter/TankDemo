using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseButton : Singleton<UIPauseButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void Pause() 
    {
        PauseManager.instance.TogglePause();
    }
}
