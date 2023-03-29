using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuitButton : Singleton<UIQuitButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void Quit() 
    {
        AudioManager.instance.PlaySelect();
        Application.Quit();
    }
}
