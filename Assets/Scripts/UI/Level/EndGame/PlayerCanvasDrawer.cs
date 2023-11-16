using UI.Level.EndGame.Panels;
using UnityEngine;

namespace UI.Level.EndGame
{
    public class PlayerCanvasDrawer : MonoBehaviour
    {
        [SerializeField] private OrangesCountText _orangesCountText;
        [field: SerializeField] public WinPanel WinPanel { get; private set; }
        [field: SerializeField] public LosePanel LosePanel { get; private set;}

        public void DrawWinPanel()
        {
            WinPanel.gameObject.SetActive(true);
            _orangesCountText.SetCountText();
        }

        public void DrawDefeatPanel()
        {
            LosePanel.gameObject.SetActive(true);
        }
    }
}