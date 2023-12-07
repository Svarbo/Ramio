using Data;
using Infrastructure;
using Infrastructure.StateMachines;
using Infrastructure.States.Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    [RequireComponent(typeof(Button))]
    public class MainMenuButton : MonoBehaviour
    {
        private Button _button;
        private StateMachine _stateMachine;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _stateMachine = FindObjectOfType<GameBootstrap>().AppCore.StateMachine;
        }

        private void OnEnable() =>
            _button.onClick.AddListener(EnableMainMenu);

        private void OnDisable() =>
            _button.onClick.RemoveListener(EnableMainMenu);

        private void EnableMainMenu()
        {
            LevelsInfo levelsInfo = new LevelsInfo();
            levelsInfo.SceneName = Levels.MainMenu.ToString();
            _stateMachine.Enter(typeof(LoadLevelState), levelsInfo);
        }
    }
}