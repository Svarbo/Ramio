using System;
using Players;
using UI.Level.EndGame.Panels;
using UnityEngine;

namespace UI.Level.EndGame
{
    public class PlayerCanvasDrawer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private WinPanel _winPanel;
        [SerializeField] private DefeatPanel _defeatPanel;
        [SerializeField] private GratitudePanel _gratitudePanel;

        public event Action FinishZoneTrigerred;
        
        public WinPanel WinPanel => _winPanel;
        public DefeatPanel DefeatPanel => _defeatPanel;

        private void OnEnable() =>
            _player.Desappeared += ShowDefeatPanel;

        private void OnDisable() =>
            _player.Desappeared -= ShowDefeatPanel;

        public void ShowWinPanel()
        {
            FinishZoneTrigerred?.Invoke();
            _winPanel.gameObject.SetActive(true);
        }

        public void ShowGratitudePanel()
        {
            _gratitudePanel.gameObject.SetActive(true);
        }

        private void ShowDefeatPanel()
        {
            _defeatPanel.gameObject.SetActive(true);
        }
    }
}