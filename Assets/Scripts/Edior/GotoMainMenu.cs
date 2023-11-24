using UnityEngine;
using UnityEngine.UI;

namespace Edior
{
    // TODO Переименовать класс и перенести его в UI
    public class GotoMainMenu : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private GameBootstrap _gameBootstrap;
        private LevelBootstrap _levelBootstrap;

        private void Start() =>
            _gameBootstrap = FindObjectOfType<GameBootstrap>();

        private void OnEnable() =>
            _button.onClick.AddListener(GotoMenu);

        private void OnDisable() =>
            _button.onClick.RemoveListener(GotoMenu);

        private void GotoMenu()
        {
            LevelsInfo levelsInfo = FindObjectOfType<LevelBootstrap>().LevelsInfo;
            levelsInfo.SceneName = Levels.MainMenu.ToString();
            _gameBootstrap.AppCore.StateMachine.Enter(typeof(LoadLevelState), levelsInfo);
        }
    }
}