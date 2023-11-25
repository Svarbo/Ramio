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

    public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo, InputServiceView playerInputServiceView)
    {
        _playerInputServiceView = playerInputServiceView;
        _levelsInfo = levelsInfo;
        
        WinPanel.Construct(stateMachine, levelsInfo);
        LosePanel.Construct(stateMachine, levelsInfo);
    }

    public void DrawWinPanel(int score)
    {
        _orangesCountText.SetCountText(score, PlayerPrefs.GetInt("CurrentLevelOrangesCount"));
        WinPanel.gameObject.SetActive(true);

        IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult);
        
        if (_levelsInfo.CurrentDifficult != typeof(Hard))
        {
            difficult.GetAcceptLevels();
            difficult.IncreaseAcceptLevels(SceneManager.GetActiveScene().name);
        }
    }

    public void DrawDefeatPanel() =>
        LosePanel.gameObject.SetActive(true);

    public void DrawFinishPanel() =>
        FinishPanel.gameObject.SetActive(true);
}