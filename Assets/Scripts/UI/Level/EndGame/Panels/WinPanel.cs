using System;
using Data;
using Infrastructure.States.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StateMachine = Infrastructure.StateMachines.StateMachine;

namespace UI.Level.EndGame.Panels
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _mainMenuButton;

        private StateMachine _stateMachine;
        private LevelsInfo _levelsInfo;

        private void OnEnable()
        {
            _nextLevelButton.onClick.AddListener(LoadNextLevel);
            _mainMenuButton.onClick.AddListener(LoadMainMenu);
        }

        private void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(LoadNextLevel);
            _mainMenuButton.onClick.RemoveListener(LoadMainMenu);
        }

        public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo)
        {
            _levelsInfo = levelsInfo;
            _stateMachine = stateMachine;
        }

        private void LoadNextLevel()
        {
            string currentLevelName = SceneManager.GetActiveScene().name;
            string levelName = currentLevelName.Substring(currentLevelName.Length - 1);

            if (int.TryParse(levelName, out int number))
                number++;
            else
                throw new InvalidOperationException(levelName);

            currentLevelName = currentLevelName.Remove(currentLevelName.Length - 1);
            currentLevelName += number.ToString();

            _levelsInfo.SceneName = currentLevelName;
            _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
        }

        private void LoadMainMenu()
        {
            _levelsInfo.SceneName = "MainMenu";
            _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
        }
    }
}