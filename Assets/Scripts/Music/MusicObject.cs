using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    private void Awake()
    {
        AudioManager.instance.AudioToggled += ToggleMusic;
        source.mute = !AudioManager.instance.GetAudioOn();
    }

    private void ToggleMusic() 
    {
        source.mute = !AudioManager.instance.GetAudioOn();
    }
}
