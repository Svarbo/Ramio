using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCanvasDrawer : MonoBehaviour
{
    [SerializeField] private OrangesCountText _orangesCountText;

    [field: SerializeField] public WinPanel WinPanel { get; private set; }
    [field: SerializeField] public DefeatPanel LosePanel { get; private set; }

    private LevelsInfo _levelsInfo;
    
    public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo)
    {
        _levelsInfo = levelsInfo;
        WinPanel.Construct(stateMachine, levelsInfo);
        LosePanel.Construct(stateMachine, levelsInfo);
    }

    public void DrawWinPanel(int score)
    {
        _orangesCountText.SetCountText(score, PlayerPrefs.GetInt("CurrentLevelOrangesCount"));
        WinPanel.gameObject.SetActive(true);

        if (_levelsInfo.CurrentDifficult != typeof(Hard))
        {
            IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult);
            difficult.GetAcceptLevels();
            difficult.IncreaseAcceptLevels(SceneManager.GetActiveScene().name);
        }
    }

    public void DrawDefeatPanel() =>
        LosePanel.gameObject.SetActive(true);
}