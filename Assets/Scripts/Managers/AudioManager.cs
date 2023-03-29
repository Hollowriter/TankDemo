using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private bool _audioOn;
    [SerializeField] AudioClip select;
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip score;
    [SerializeField] AudioSource source;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        _audioOn = true;
        DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void PlaySelect() 
    {
        if (_audioOn)
        {
            source.Stop();
            source.clip = select;
            source.Play();
        }
    }

    public void PlayShoot()
    {
        if (_audioOn)
        {
            source.Stop();
            source.clip = shoot;
            source.Play();
        }
    }

    public void PlayScore()
    {
        if (_audioOn)
        {
            source.Stop();
            source.clip = score;
            source.Play();
        }
    }

    public void ToggleAudio(bool audioOn) 
    {
        _audioOn = audioOn;
    }

    public bool GetAudioOn() 
    {
        return _audioOn;
    }
}
