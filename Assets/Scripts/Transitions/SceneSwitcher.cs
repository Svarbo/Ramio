using UnityEngine;
using UnityEngine.Events;

namespace Transitions
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private Fader _fader;
        [SerializeField] private GameLoader _gameLoader;

        public event UnityAction IsReadyToLoadMainMenu;
        public event UnityAction IsReadyToLoadLevel;

        public void LoadMainMenu() =>
            _fader.FadeIn(IsReadyToLoadMainMenu);

        public void LoadLevel(int levelIndex)
        {
            _gameLoader.SetCurrentLevelIndex(levelIndex);
            _fader.FadeIn(IsReadyToLoadLevel);
        }

        public void RestartCurrentLevel() =>
            _fader.FadeIn(IsReadyToLoadLevel);

        public void TryLoadNextLevel()
        {
            _gameLoader.TrySwitchToNextLevel();
            _fader.FadeIn(IsReadyToLoadLevel);
        }
    }
}