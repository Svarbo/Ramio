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
        [SerializeField] private Button _nextLevelButton;

        private void OnEnable()
        {
            SetScoreText();
            //_nextLevelButton.onClick.AddListener(LoadNextLevel);
        }

        private void OnDisable()
        {
            //_nextLevelButton.onClick.RemoveListener(LoadNextLevel);
        }

        private void SetScoreText() =>
            _orangesCountText.SetCountText(_personage.FruitsCount, PlayerPrefs.GetInt(PlayerPrefsNames.CurrentLevelOrangesCount));

        
    }
}