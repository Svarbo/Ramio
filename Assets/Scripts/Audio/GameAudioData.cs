using System;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "GameAudioData", menuName = "ScriptableObject/Audio", order = 0)]
    public class GameAudioData : ScriptableObject
    {
        [field: SerializeField] public float EffectsVolume { get; private set; }
        [field: SerializeField] public float MusicVolume { get; private set; }

        public event Action<float> EffectsVolumeChanged;
        public event Action<float> MusicCVolumeChanged;

        public void SetEffectsVolume(float newVolume)
        {
            EffectsVolume = newVolume;
            EffectsVolumeChanged?.Invoke(newVolume);
        }

        public void SetMusicVolume(float newVolume)
        {
            MusicVolume = newVolume;
            MusicCVolumeChanged?.Invoke(newVolume);
        }
    }
}