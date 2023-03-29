using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudioToggle : Singleton<UIAudioToggle>
{
    [SerializeField] Toggle toggle;
    protected override void SingletonAwake()
    {
        base.SingletonAwake();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    private void Start()
    {
        toggle.isOn = AudioManager.instance.GetAudioOn();
    }

    public void ToggleAudio() 
    {
        AudioManager.instance.ToggleAudio(toggle.isOn);
        AudioManager.instance.PlaySelect();
    }
}
