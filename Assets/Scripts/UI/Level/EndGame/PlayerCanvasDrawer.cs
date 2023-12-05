using Infrastructure.Inputs;
using Players;
using UI.Level.EndGame.Panels;
using UnityEngine;

namespace UI.Level.EndGame
{
    public class PlayerCanvasDrawer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private InputServiceView _playerInput;
        [SerializeField] private WinPanel _winPanel;
        [SerializeField] private DefeatPanel _defeatPanel;
        [SerializeField] private GratitudePanel _gratitudePanel;
        [SerializeField] private MainMenuButton _mainMenuButton;

        private void OnEnable() =>
            _player.Desappeared += ShowDefeatPanel;

        private void OnDisable() =>
            _player.Desappeared -= ShowDefeatPanel;

        public void ShowWinPanel()
        {
            _mainMenuButton.gameObject.SetActive(false);
            _playerInput.gameObject.SetActive(false);

            _winPanel.gameObject.SetActive(true);
        }

        public void ShowGratitudePanel()
        {
            _mainMenuButton.gameObject.SetActive(false);
            _playerInput.gameObject.SetActive(false);

            _gratitudePanel.gameObject.SetActive(true);
        }

        private void ShowDefeatPanel()
        {
            _mainMenuButton.gameObject.SetActive(false);
            _playerInput.gameObject.SetActive(false);

            _defeatPanel.gameObject.SetActive(true);
        }
    }
}