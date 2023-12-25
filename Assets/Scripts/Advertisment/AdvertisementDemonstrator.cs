using System;
using Agava.YandexGames;
using Audio;
using ConstantValues;
using UnityEngine;

namespace Advertisment
{
    public class AdvertisementDemonstrator : MonoBehaviour
    {
        private const int AdvertisementDemonstrationFrequency = 3;

        [SerializeField] private GameAudioData _gameAudioData;

        private float _musicVolume;
        private float _effectVolume;
        private Action Callback;

        private void Awake() =>
            _musicVolume = _gameAudioData.MusicVolume;

        public void TryShowAdvertisement(Action OnSuccesCallback)
        {
            Callback += OnSuccesCallback;

            int attemptsCount = PlayerPrefs.GetInt(PlayerPrefsNames.AttemptsCount);

            if (attemptsCount % AdvertisementDemonstrationFrequency == 0)
                InterstitialAd.Show(OnStartCallBack, OnCloseCallback, OnErrorCallback);
            else
                OnSuccesCallback?.Invoke();
        }

        private void OnCloseCallback(bool obj)
        {
            Callback?.Invoke();
            
            _gameAudioData.SetMusicVolume(_musicVolume);
            _gameAudioData.SetEffectsVolume(_effectVolume);
            
            Time.timeScale = 1;
        }

        private void OnStartCallBack()
        {
            Time.timeScale = 0;
            
            _musicVolume = _gameAudioData.MusicVolume;
            _gameAudioData.SetMusicVolume(0);
            
            _effectVolume = _gameAudioData.EffectsVolume;
            _gameAudioData.SetEffectsVolume(0);
        }

        private void OnErrorCallback(string obj)
        {
            Callback?.Invoke();

            _gameAudioData.SetMusicVolume(_musicVolume);
            _gameAudioData.SetEffectsVolume(_effectVolume);
            
            Time.timeScale = 1;
        }
    }
}