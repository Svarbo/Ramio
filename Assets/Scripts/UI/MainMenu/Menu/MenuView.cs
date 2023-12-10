using Transitions;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.Menu
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private MenuSwitcher _menuSwitcher;
        [SerializeField] private Button _levelMenuButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _leaderboardButton;

        private void OnEnable()
        {
            _levelMenuButton.onClick.AddListener(_menuSwitcher.EnableLevelMenu);
            _settingsButton.onClick.AddListener(_menuSwitcher.EnableSettings);
            _leaderboardButton.onClick.AddListener(_menuSwitcher.EnableLeaderboard);
        }

        private void OnDisable()
        {
            _levelMenuButton.onClick.RemoveListener(_menuSwitcher.EnableLevelMenu);
            _settingsButton.onClick.RemoveListener(_menuSwitcher.EnableSettings);
            _leaderboardButton.onClick.RemoveListener(_menuSwitcher.EnableLeaderboard);
        }
    }
}