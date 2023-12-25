using System;
using Advertisment;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.EndGame.Panels
{
    public class DefeatPanel : MonoBehaviour
    {
        [SerializeField] private AdvertisementDemonstrator _advertisementDemonstrator;
        [SerializeField] private Button _restartButton;

        public event Action LevelRestarted;

        private void OnEnable() =>
            _restartButton.onClick.AddListener(OnRestartButtonClicked);

        private void OnDisable() =>
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);

        private void OnRestartButtonClicked() =>
            _advertisementDemonstrator.TryShowAdvertisement(InvokeButtonLevelRestarter);

        private void InvokeButtonLevelRestarter() =>
            LevelRestarted?.Invoke();
    }
}