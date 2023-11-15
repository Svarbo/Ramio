using UnityEngine;

namespace Level.Audio
{
    public class AudioEffects : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private GameAudioData _gameAudioData;

        private void OnEnable()
        {
            ChangeVolume(_gameAudioData.Effects);
            _gameAudioData.EffectsVolumeChangeed += ChangeVolume;
        }

        private void OnDisable() =>
            _gameAudioData.EffectsVolumeChangeed -= ChangeVolume;

        public void ChangeVolume(float value)
        {
            float volume = Mathf.Clamp01(value);
            _audioSource.volume = volume;
        }
    }
}