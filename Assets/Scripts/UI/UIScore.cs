using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : Singleton<UIScore>
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        ScoreManager.instance.ScoreChanged += RefreshScore;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    private void Start()
    {
        RefreshScore();
    }

    private void RefreshScore() 
    {
        scoreText.text = "Score: " + ScoreManager.instance.GetScore();
    }
}
