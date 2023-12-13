using UnityEngine;

namespace Audio
{
    public class BackgroundMusicFixer : MonoBehaviour
    {
        [SerializeField] private GameAudioData _gameAudioData;

        private float _musicVolume;

        private void Awake() =>
            _musicVolume = _gameAudioData.MusicVolume;

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                _gameAudioData.SetMusicVolume(_musicVolume);
                Time.timeScale = 1f;
            }
            else
            {
                _musicVolume = _gameAudioData.MusicVolume;
                _gameAudioData.SetMusicVolume(0);
                Time.timeScale = 0f;
            }
        }
    }
}