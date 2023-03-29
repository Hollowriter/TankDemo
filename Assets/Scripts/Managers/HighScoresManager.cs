using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoresManager : Singleton<HighScoresManager>
{
    private int firstPlace;
    private int secondPlace;
    private int thirdPlace;

    public delegate void OnHighScoresChecked();
    public OnHighScoresChecked HighScoresChecked;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        firstPlace = PlayerPrefs.GetInt("FirstPlace");
        secondPlace = PlayerPrefs.GetInt("SecondPlace");
        thirdPlace = PlayerPrefs.GetInt("ThirdPlace");
        GameOverManager.instance.Over += CheckForHighScore;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    private void CheckForHighScore() 
    {
        if (ScoreManager.instance.GetScore() > firstPlace) 
        {
            PlayerPrefs.SetInt("ThirdPlace", PlayerPrefs.GetInt("SecondPlace"));
            PlayerPrefs.SetInt("SecondPlace", PlayerPrefs.GetInt("FirstPlace"));
            PlayerPrefs.SetInt("FirstPlace", ScoreManager.instance.GetScore());
            HighScoresChecked();
            return;
        }
        if (ScoreManager.instance.GetScore() > secondPlace) 
        {
            PlayerPrefs.SetInt("ThirdPlace", PlayerPrefs.GetInt("SecondPlace"));
            PlayerPrefs.SetInt("SecondPlace", ScoreManager.instance.GetScore());
            HighScoresChecked();
            return;
        }
        if (ScoreManager.instance.GetScore() > thirdPlace) 
        {
            HighScoresChecked();
            PlayerPrefs.SetInt("ThirdPlace", ScoreManager.instance.GetScore());
            return;
        }
        HighScoresChecked();
    }
}
