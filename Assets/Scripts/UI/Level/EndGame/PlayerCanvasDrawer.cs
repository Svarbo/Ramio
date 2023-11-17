using UnityEngine;

public class PlayerCanvasDrawer : MonoBehaviour
{
    [SerializeField] private OrangesCountText _orangesCountText;
    [field: SerializeField] public WinPanel WinPanel { get; private set; }
    [field: SerializeField] public LosePanel LosePanel { get; private set; }

    public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo)
    {
        WinPanel.Construct(stateMachine, levelsInfo);
        LosePanel.Construct(stateMachine, levelsInfo);
    }
    
    public void DrawWinPanel(int score)
    {
        _orangesCountText.SetCountText(score, PlayerPrefs.GetInt("CurrentLevelOrangesCount"));
        WinPanel.gameObject.SetActive(true);
    }

    public void DrawDefeatPanel() =>
        LosePanel.gameObject.SetActive(true);
}