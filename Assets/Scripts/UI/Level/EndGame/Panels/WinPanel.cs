using System;
using CollectableObjects;
using ConstantValues;
using Players;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.EndGame.Panels
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private Player _personage;
        [SerializeField] private OrangesCountText _orangesCountText;
        [SerializeField] private Button _button;

        public event Action NextLevelLoader;
        private void OnEnable()
        {
            _button.onClick.AddListener(LoadNextLevel);
            SetScoreText();
        }

        private void OnDisable() => 
            _button.onClick.RemoveListener(LoadNextLevel);

        private void LoadNextLevel() => 
            NextLevelLoader?.Invoke();

        private void SetScoreText() =>
            _orangesCountText.SetCountText(_personage.FruitsCount, PlayerPrefs.GetInt(PlayerPrefsNames.CurrentLevelOrangesCount));
    }
}