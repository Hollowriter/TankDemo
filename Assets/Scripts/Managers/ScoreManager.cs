using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _score;

    public delegate void OnScoreChanged();
    public OnScoreChanged ScoreChanged;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        _score = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetScore(int score) 
    {
        _score = score;
        ScoreChanged();
    }

    public void AddScore(int score)
    {
        _score += score;
        ScoreChanged();
    }

    public int GetScore() 
    {
        return _score;
    }
}
