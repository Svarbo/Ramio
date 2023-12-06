using Agava.YandexGames;
using ConstantValues;
using System;
using UnityEngine;

namespace SDK
{
    public class AdvertisementDemonstrator : MonoBehaviour
    {
        private const int AdvertisementDemonstrationFrequency = 4;

        public void TryShowAdvertisement(Action<bool> OnCloseCallback = null, Action<string> OnErrorCallback = null)
		{
			int attemptsCount = PlayerPrefs.GetInt(PlayerPrefsNames.AttemptsCount);

            if (attemptsCount % AdvertisementDemonstrationFrequency == 0)
                InterstitialAd.Show(OnStartCallBack, OnCloseCallback, OnErrorCallback);
        }
        
        // TODO выключить музыку
        private void OnStartCallBack() =>
            Time.timeScale = 0;

        //TODO: Вынести в отдельный класс
        //private void OnErrorCallback(string obj) =>
        //	RestartLevel();

        //private void OnCloseCallback(bool isClosed)
        //{
        //	Time.timeScale = 1;

        //	if (isClosed)
        //		RestartLevel();
        //}
    }
}