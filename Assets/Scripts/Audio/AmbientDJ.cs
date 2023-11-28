using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(BackgroundMusic))]
    public class AmbientDJ : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();

        private AudioSource _audioSource;
        private AudioClip _currentAudioClip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            ChooseRandomAudioClip();
            PlayCurrentClip();
        }

        private void ChooseRandomAudioClip()
        {
            int nextAudioClipIndex = Random.Range(0, _audioClips.Count);
            _currentAudioClip = _audioClips[nextAudioClipIndex];
        }

        private void PlayCurrentClip()
        {
            _audioSource.clip = _currentAudioClip;
            _audioSource.Play();
        }
    }
}