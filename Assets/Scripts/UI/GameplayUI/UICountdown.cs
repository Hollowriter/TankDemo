using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICountdown : Singleton<UICountdown>
{
    [SerializeField] private TMPro.TextMeshProUGUI countdownText;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        CountdownManager.instance.TimeChanged += RefreshTime;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    private void Start()
    {
        RefreshTime();
    }

    private void RefreshTime() 
    {
        countdownText.text = "Time: " + CountdownManager.instance.GetTimer();
    }
}
