using Data;
using Infrastructure;
using Infrastructure.States.Scenes;
using Level;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    [RequireComponent(typeof(Button))]
    public class MainMenuButton : MonoBehaviour
    {
        private Button _button;
        private GameBootstrap _gameBootstrap;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.onClick.AddListener(OpenMainMenu);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OpenMainMenu);

        private void Start() =>
            _gameBootstrap = FindObjectOfType<GameBootstrap>();

        private void OpenMainMenu()
        {
            LevelsInfo levelsInfo = FindObjectOfType<LevelBootstrap>().LevelsInfo;
            levelsInfo.SceneName = Levels.MainMenu.ToString();
            _gameBootstrap.AppCore.StateMachine.Enter(typeof(LoadLevelState), levelsInfo);
        }
    }
}