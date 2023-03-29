using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : Singleton<GameOverManager>
{
    private bool _gameIsOver;

    public delegate void OnGameOver();
    public OnGameOver Over;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        _gameIsOver = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public bool GameOver() 
    {
        return _gameIsOver;
    }

    public void MakeTheGameOver() 
    {
        _gameIsOver = true;
        Over();
    }
}
