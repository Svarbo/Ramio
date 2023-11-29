using Data;
using Data.Difficults;
using Infrastructure.States.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StateMachine = Infrastructure.StateMachines.StateMachine;

namespace UI.Level.EndGame.Panels
{
    public class DefeatPanel : MonoBehaviour
    {
        private const int AdvertisementDemonstrationFrequency = 4;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        private StateMachine _stateMachine;
        private LevelsInfo _levelsInfo;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(TryShowAdvertisement);
            _mainMenuButton.onClick.AddListener(OpenMainMenu);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(TryShowAdvertisement);
            _mainMenuButton.onClick.RemoveListener(OpenMainMenu);
        }

        public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo)
        {
            _levelsInfo = levelsInfo;
            _stateMachine = stateMachine;
        }

        private void TryShowAdvertisement()
        {
            int attemptsCount = UnityEngine.PlayerPrefs.GetInt("AttemptsCount");
        
            //TODO Включить 
            // if (attemptsCount % AdvertisementDemonstrationFrequency == 0)
            //     InterstitialAd.Show(OnStartCallBack, OnCloseCallback);
            // else
            RestartLevel();
        }

        private void RestartLevel()
        {
            if (_levelsInfo.CurrentDifficult == typeof(Hard))
            {
                _levelsInfo.SceneName = Levels.Level0.ToString();
                _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
            }
            else
            {
                _levelsInfo.SceneName = SceneManager.GetActiveScene().name;
                _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
            }
        }

        private void OnStartCallBack() => 
            Time.timeScale = 0;

        private void OnCloseCallback(bool isClosed)
        {
            Time.timeScale = 1;

            if (isClosed)
                RestartLevel();
        }

        private void OpenMainMenu()
        {
            _levelsInfo.SceneName = Levels.MainMenu.ToString();
            _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
        }
    }
}