using Agava.YandexGames;
using ConstantValues;
using System;
using Audio;
using UnityEngine;

namespace SDK
{
    public class AdvertisementDemonstrator : MonoBehaviour
    {
        private const int AdvertisementDemonstrationFrequency = 4;

        [SerializeField] private GameAudioData _gameAudioData;

        private Action Callback;
        private float _musicVolume;

        private void Awake() => 
            _musicVolume = _gameAudioData.MusicVolume;

        public void TryShowAdvertisement(Action OnSuccesCallback)
        {
            Callback += OnSuccesCallback;

            int attemptsCount = PlayerPrefs.GetInt(PlayerPrefsNames.AttemptsCount);

            if (attemptsCount % AdvertisementDemonstrationFrequency == 0)
                InterstitialAd.Show(OnStartCallBack, OnCloseCallback, OnErrorCallback);
        }

        private void OnCloseCallback(bool obj)
        {
            Callback?.Invoke();
            _gameAudioData.SetMusicVolume(_musicVolume);
            Time.timeScale = 1;
        }

        private void OnStartCallBack()
        {
            Time.timeScale = 0;
            _musicVolume = _gameAudioData.MusicVolume;
            _gameAudioData.SetMusicVolume(0); 
        }

        private void OnErrorCallback(string obj)
        {
            Callback?.Invoke();
            _gameAudioData.SetMusicVolume(_musicVolume);
            Time.timeScale = 1;
        }
    }
}