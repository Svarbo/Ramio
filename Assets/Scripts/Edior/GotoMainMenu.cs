using UnityEngine;
using UnityEngine.UI;

namespace Edior
{
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
            var s = FindObjectOfType<LevelBootstrap>()._levelsInfo;
            s.SceneName = "MainMenu";
            _gameBootstrap.AppCore.StateMachine.Enter(typeof(LoadLevelState), s);
        }
    }
}