using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResumeButton : Singleton<UIResumeButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void Resume()
    {
        PauseManager.instance.TogglePause();
    }
}
