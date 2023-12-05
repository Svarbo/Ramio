using SDK;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.EndGame.Panels
{
	public class DefeatPanel : MonoBehaviour
	{
		[SerializeField] private AdvertisementDemonstrator _advertisementDemonstrator;
		[SerializeField] private Button _restartButton;
		[SerializeField] private MainMenuButton _mainMenuButton;

        private void OnEnable() =>
            _restartButton.onClick.AddListener(OnRestartButtonClicked);

        private void OnDisable() =>
			_restartButton.onClick.RemoveListener(OnRestartButtonClicked);

        private void OnRestartButtonClicked()
        {
			//_advertisementDemonstrator.TryShowAdvertisement();
        }
    }
}