using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuButton : Singleton<UIMainMenuButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
