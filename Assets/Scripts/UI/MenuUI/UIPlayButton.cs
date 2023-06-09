using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPlayButton : Singleton<UIPlayButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void Play() 
    {
        AudioManager.instance.PlaySelect();
        SceneManager.LoadScene("GameplayScene");
    }
}
