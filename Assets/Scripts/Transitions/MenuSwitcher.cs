using UI.MainMenu.Leaderboard;
using UI.MainMenu.LevelMenu;
using UI.MainMenu.Menu;
using UnityEngine;

namespace Transitions
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private MenuView _mainMenu;
        [SerializeField] private LevelMenuView _levelMenu;
        [SerializeField] private SettingsView _settings;
        [SerializeField] private LeaderboardView _leaderboard;

        public void EnableLevelMenu()
        {
            _levelMenu.gameObject.SetActive(true);
            _mainMenu.gameObject.SetActive(false);
        }

        public void EnableSettings()
        {
            _settings.gameObject.SetActive(true);
            _mainMenu.gameObject.SetActive(false);
        }

        public void EnableLeaderboard()
        {
            _leaderboard.gameObject.SetActive(true);
            _mainMenu.gameObject.SetActive(false);
        }
    }
}