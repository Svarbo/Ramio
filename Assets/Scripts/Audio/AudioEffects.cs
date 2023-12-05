using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioEffects : MonoBehaviour
    {
        [SerializeField] private GameAudioData _gameAudioData;

        private AudioSource _audioSource;

        private void Awake() =>
            _audioSource = GetComponent<AudioSource>();

        private void OnEnable()
        {
            ChangeVolume(_gameAudioData.EffectsVolume);
            _gameAudioData.EffectsVolumeChanged += ChangeVolume;
        }

        private void OnDisable() =>
            _gameAudioData.EffectsVolumeChanged -= ChangeVolume;

        public void ChangeVolume(float value)
        {
            float volume = Mathf.Clamp01(value);
            _audioSource.volume = volume;
        }
    }
}