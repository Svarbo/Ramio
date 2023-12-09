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

        // TODO не используется
        public void EnableMainMenu()
        {
            _mainMenu.gameObject.SetActive(true);

            _levelMenu.gameObject.SetActive(false);
            _settings.gameObject.SetActive(false);
            _leaderboard.gameObject.SetActive(false);
        }

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