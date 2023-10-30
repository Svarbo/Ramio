using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasDrawer : MonoBehaviour
{
    [SerializeField] private OrangesCountText _orangesCountText;
    [SerializeField] private Image _winPanel;
    [SerializeField] private Image _defeatPanel;

    public void DrawWinPanel()
    {
        _winPanel.gameObject.SetActive(true);
        _orangesCountText.SetCountText();
    }

    public void DrawDefeatPanel()
    {
        _defeatPanel.gameObject.SetActive(true);
    }
}