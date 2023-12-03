using CollectableObjects;
using Data;
using Data.Difficults;
using Edior;
using Infrastructure.Inputs;
using UI.Level.EndGame.Panels;
using UnityEngine;
using UnityEngine.SceneManagement;
using StateMachine = Infrastructure.StateMachines.StateMachine;

namespace UI.Level.EndGame
{
    public class PlayerCanvasDrawer : MonoBehaviour
    {
        [SerializeField] private OrangesCountText _orangesCountText;

        [field: SerializeField] public WinPanel WinPanel { get; private set; }
        [field: SerializeField] public DefeatPanel LosePanel { get; private set; }
        [field: SerializeField] public FinishPanel FinishPanel { get; private set; }

        private InputServiceView _playerInputServiceView;
        private MainMenuButton _mainMenuButton;

        public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo, InputServiceView playerInputServiceView, MainMenuButton mainMenuButton)
        {
            _mainMenuButton = mainMenuButton;
            _playerInputServiceView = playerInputServiceView;
            LevelsInfo = levelsInfo;

            WinPanel.Construct(stateMachine, levelsInfo);
            LosePanel.Construct(stateMachine, levelsInfo);
        }
        public LevelsInfo LevelsInfo { get; private set; }

        public void DrawWinPanel(int score)
        {
            _playerInputServiceView.Deactivate();
            _mainMenuButton.gameObject.SetActive(false);
            _orangesCountText.SetCountText(score, PlayerPrefs.GetInt("CurrentLevelOrangesCount"));
            WinPanel.gameObject.SetActive(true);

            IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(LevelsInfo.CurrentDifficult);

            if (LevelsInfo.CurrentDifficult != typeof(Hard))
            {
                difficult.GetAcceptLevels();
                difficult.IncreaseAcceptLevels();
            }
        }

        public void DrawDefeatPanel()
        {
            _mainMenuButton.gameObject.SetActive(false);
            _playerInputServiceView.Deactivate();
            LosePanel.gameObject.SetActive(true);
        }

        public void DrawFinishPanel()
        {
            _mainMenuButton.gameObject.SetActive(false);
            _playerInputServiceView.Deactivate();
            FinishPanel.gameObject.SetActive(true);
        }
    }
}