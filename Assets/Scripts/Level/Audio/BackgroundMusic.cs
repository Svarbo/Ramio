using Data;
using UnityEngine;

namespace Level.Audio
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private GameAudioData _gameAudioData;

        private void OnEnable() =>
            _gameAudioData.MusicCVolumehangeed += ChangeVolume;

        private void OnDisable() =>
            _gameAudioData.MusicCVolumehangeed -= ChangeVolume;

        public void ChangeVolume(float value)
        {
            float volume = Mathf.Clamp01(value);
            _audioSource.volume = volume;
        }
    }
}