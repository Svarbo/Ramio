using Audio;
using Infrastructure.Core;
using Transitions;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private Fader _fader;
        [SerializeField] private GameAudioData _gameAudioData;

        private float _musicVolume;

        public AppCore AppCore { get; private set; }

        private void Awake()
        {
            _musicVolume = _gameAudioData.MusicVolume;

            DontDestroyOnLoad(this);

            if (AppCore is null)
                AppCore = new AppCore(this, _fader);
        }

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