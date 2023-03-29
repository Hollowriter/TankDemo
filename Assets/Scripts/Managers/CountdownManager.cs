using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownManager : Singleton<CountdownManager>
{
    [SerializeField] private int gameTime;
    [SerializeField] private int gameSecond;
    private int _timer;
    private float _miliseconds;

    public delegate void OnTimeChanged();
    public OnTimeChanged TimeChanged;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        _timer = gameTime;
        _miliseconds = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    private void TimeTicking() 
    {
        _miliseconds += Time.deltaTime;
        if (_miliseconds >= gameSecond) 
        {
            _timer -= 1;
            _miliseconds = 0;
            TimeChanged();
        }
    }

    private void EndGame() 
    {
        if (_timer <= 0 && !GameOverManager.instance.GameOver())
            GameOverManager.instance.MakeTheGameOver();
    }

    public int GetTimer() 
    {
        return _timer;
    }

    protected override void BehaveSingleton()
    {
        base.BehaveSingleton();
        TimeTicking();
        EndGame();
    }

    private void Update()
    {
        if (!PauseManager.instance.GetPaused())
            BehaveSingleton();
    }
}
