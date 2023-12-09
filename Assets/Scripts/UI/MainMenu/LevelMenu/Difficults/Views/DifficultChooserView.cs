using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.LevelMenu.Difficults.Views
{
    public class DifficultChooserView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [field: SerializeField] public DifficultInfoPanel DifficultInfoPanel { get; private set; }

        private void OnEnable() =>
            _button.onClick.AddListener(Clicked);

        private void OnDisable() =>
            _button.onClick.RemoveListener(Clicked);

        private void Clicked() =>
            DifficultInfoPanel.gameObject.SetActive(true);
    }
}