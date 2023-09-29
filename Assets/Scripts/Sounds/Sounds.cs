using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSources = new List<AudioSource>();

    private void Start()
    {
        SetVolumeValues();
    }

    public void SetVolumeValues()
    {
        float volume = PlayerPrefs.GetFloat("Volume");

        foreach(AudioSource audioSource in _audioSources)
            audioSource.volume = volume;
    }

    public void Stop()
    {
        foreach (AudioSource audioSource in _audioSources)
            audioSource.volume = 0;
    }
}