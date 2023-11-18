using UnityEngine;

public class PlayerCanvasDrawer : MonoBehaviour
{
    [SerializeField] private OrangesCountText _orangesCountText;
    private LevelsInfo _levelsInfo;
    [field: SerializeField] public WinPanel WinPanel { get; private set; }
    [field: SerializeField] public LosePanel LosePanel { get; private set; }

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

        IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult);
        difficult.IncreaseAcceptLevels();
    }

    public void DrawDefeatPanel() =>
        LosePanel.gameObject.SetActive(true);
}