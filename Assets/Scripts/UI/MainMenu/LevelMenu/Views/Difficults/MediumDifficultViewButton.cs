using UI.MainMenu.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.Views
{
    public class MediumDifficultViewButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private DifficultChooserPresenter _difficultChooserPresenter;
        
        private void OnEnable() =>
            _button.onClick.AddListener(OnClicked);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnClicked);

        public void Construct(DifficultChooserPresenter difficultChooserPresenter) =>
            _difficultChooserPresenter = difficultChooserPresenter;

        private void OnClicked() =>
            _difficultChooserPresenter.SetMediumDifficult();
    }
}