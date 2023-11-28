using Assets.Scripts.Data;
using Assets.Scripts.Data.Difficults;
using Assets.Scripts.Edior;
using Assets.Scripts.Infrastructure.Inputs;
using Assets.Scripts.Infrastructure.StateMachines;
using CollectableObjects;
using UI.Level.EndGame.Panels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCanvasDrawer : MonoBehaviour
{
    [SerializeField] private OrangesCountText _orangesCountText;

    [field: SerializeField] public WinPanel WinPanel { get; private set; }
    [field: SerializeField] public DefeatPanel LosePanel { get; private set; }
    [field: SerializeField] public FinishPanel FinishPanel { get; private set; }

    private LevelsInfo _levelsInfo;
    private InputServiceView _playerInputServiceView;
    private MainMenuButton _mainMenuButton;

    public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo, InputServiceView playerInputServiceView, MainMenuButton mainMenuButton)
    {
        _mainMenuButton = mainMenuButton;
        _playerInputServiceView = playerInputServiceView;
        _levelsInfo = levelsInfo;

        WinPanel.Construct(stateMachine, levelsInfo);
        LosePanel.Construct(stateMachine, levelsInfo);
    }

    public void DrawWinPanel(int score)
    {
        _playerInputServiceView.Deactivate();
        _mainMenuButton.gameObject.SetActive(false);
        _orangesCountText.SetCountText(score, PlayerPrefs.GetInt("CurrentLevelOrangesCount"));
        WinPanel.gameObject.SetActive(true);

        IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult);

        if (_levelsInfo.CurrentDifficult != typeof(Hard))
        {
            difficult.GetAcceptLevels();
            difficult.IncreaseAcceptLevels(SceneManager.GetActiveScene().name);
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