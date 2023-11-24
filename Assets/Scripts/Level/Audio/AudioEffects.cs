using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioEffects : MonoBehaviour
{
    [SerializeField] private GameAudioData _gameAudioData;

    private AudioSource _audioSource;

    private void Awake() =>
        _audioSource = GetComponent<AudioSource>();

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