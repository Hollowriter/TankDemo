using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : Singleton<UIGameOver>
{
    [SerializeField] private Image gameOverBackground;
    [SerializeField] private TMPro.TextMeshProUGUI gameOverText;
    [SerializeField] private Button mainMenuButton;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        gameOverBackground.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        GameOverManager.instance.Over += ActivateGameOverScreen;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    private void ActivateGameOverScreen() 
    {
        gameOverBackground.gameObject.SetActive(GameOverManager.instance.GameOver());
        gameOverText.gameObject.SetActive(GameOverManager.instance.GameOver());
        mainMenuButton.gameObject.SetActive(GameOverManager.instance.GameOver());
    }
}
