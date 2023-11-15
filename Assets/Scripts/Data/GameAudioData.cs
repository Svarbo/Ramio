using System;
using DefaultNamespace.Observers;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameAudioData", menuName = "ScriptableObject/Audio", order = 0)]
    public class GameAudioData : ScriptableObject
    {
        [field: SerializeField] public float Effects { get; private set; }
        [field: SerializeField] public  float Music { get; private set; }

        public event Action<float> EffectsVolumeChangeed;
        public event Action<float> MusicCVolumehangeed;

        public void SetEffectsVolume(float newVolume)
        {
            Effects = newVolume;
            EffectsVolumeChangeed?.Invoke(newVolume);
        }

        public void SetMusicVolume(float newVolume)
        {
            Music = newVolume;
            MusicCVolumehangeed?.Invoke(newVolume);
        }
    }
}