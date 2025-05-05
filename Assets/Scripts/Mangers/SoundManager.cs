using System;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _soundEfectManager;
    public static Action<AudioClip,float> playEffect;

    void OnEnable()
    {
        playEffect += PlayEffect;
    }
    void OnDisable()
    {
        playEffect -= PlayEffect;
    }

    private void PlayEffect(AudioClip sound,float volume)
    {
        if (sound != null)  _soundEfectManager.PlayOneShot(sound, volume);
    }
}

