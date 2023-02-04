using System;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : SingletonMono<SoundManager>
{
    [SerializeField] AudioClips clips;

    bool isSoundEnabled = true;
    List<AudioSource> audioSources;
    AudioSource _bgMusicSource;

    public void UpdateSoundState()
    {
        isSoundEnabled = SaveManager.Instance.SoundEnabled;
    }

    protected override void Awake()
    {
        base.Awake();
        UpdateSoundState();

    }
    public void Play(SoundFor soundFor)
    {
        if (!isSoundEnabled)
        {
            return;
        }
        switch (soundFor)
        {
            case SoundFor.BUTTON_CLICKED:
                GetAudioSource().PlayOneShot(clips.buttonClicked);
                break;
            default:

                break;
        }
    }
    public void PlayBackgroundMusic()
    {
        if (!SaveManager.Instance.MusicEnabled)
        {
            return;
        }
        _bgMusicSource = GetAudioSource();
        _bgMusicSource.clip = clips.bg;
        _bgMusicSource.loop = true;
        _bgMusicSource.Play();
        audioSources.Remove(_bgMusicSource);
    }
    public void StopBackgroundMusic()
    {

        if (_bgMusicSource != null)
        {
            _bgMusicSource.Stop();
        }
    }



    AudioSource GetAudioSource()
    {

        if (audioSources == null)
        {
            audioSources = new List<AudioSource>();
            audioSources.Add(gameObject.AddComponent<AudioSource>());
            return audioSources[0];
        }
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                return audioSource;
            }
        }
        audioSources = new List<AudioSource>();
        audioSources.Add(gameObject.AddComponent<AudioSource>());
        return audioSources[audioSources.Count - 1];
    }
}
