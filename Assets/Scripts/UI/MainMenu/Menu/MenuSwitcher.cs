using UI.MainMenu.Leaderboard;
using UI.MainMenu.LevelMenu;
using UnityEngine;

namespace UI.MainMenu.Menu
{
    public class MenuSwitcherView : MonoBehaviour
    {
        [SerializeField] private MenuView _menuView;
        [SerializeField] private LevelMenuView _levelMenuView;
        [SerializeField] private SettingsView _settingsView;
        [SerializeField] private LeaderboardView _leaderboardView;

        public void EnableMainMenu()
        {
            _menuView.gameObject.SetActive(true);

            _levelMenuView.gameObject.SetActive(false);
            _settingsView.gameObject.SetActive(false);
            _leaderboardView.gameObject.SetActive(false);
        }

        public void EnableLevelMenu()
        {
            _levelMenuView.gameObject.SetActive(true);
            _menuView.gameObject.SetActive(false);
        }

        public void EnableSettings()
        {
            _settingsView.gameObject.SetActive(true);
            _menuView.gameObject.SetActive(false);
        }

        public void EnableLeaderboard()
        {
            _leaderboardView.gameObject.SetActive(true);
            _menuView.gameObject.SetActive(false);
        }
    }
}