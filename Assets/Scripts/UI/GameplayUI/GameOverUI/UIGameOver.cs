using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : Singleton<UIGameOver>
{
    [SerializeField] private Image gameOverBackground;
    [SerializeField] private TMPro.TextMeshProUGUI gameOverText;
    [SerializeField] private TMPro.TextMeshProUGUI firstPlaceText;
    [SerializeField] private TMPro.TextMeshProUGUI secondPlaceText;
    [SerializeField] private TMPro.TextMeshProUGUI thirdPlaceText;
    [SerializeField] private Button mainMenuButton;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        gameOverBackground.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        firstPlaceText.gameObject.SetActive(false);
        secondPlaceText.gameObject.SetActive(false);
        thirdPlaceText.gameObject.SetActive(false);
        GameOverManager.instance.Over += ActivateGameOverScreen;
        HighScoresManager.instance.HighScoresChecked += ShowHighScores;
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
        firstPlaceText.gameObject.SetActive(GameOverManager.instance.GameOver());
        secondPlaceText.gameObject.SetActive(GameOverManager.instance.GameOver());
        thirdPlaceText.gameObject.SetActive(GameOverManager.instance.GameOver());
    }

    private void ShowHighScores() 
    {
        firstPlaceText.text = "1. " + PlayerPrefs.GetInt("FirstPlace");
        secondPlaceText.text = "2. " + PlayerPrefs.GetInt("SecondPlace");
        thirdPlaceText.text = "3. " + PlayerPrefs.GetInt("ThirdPlace");
    }
}
