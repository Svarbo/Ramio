using UI.MainMenu.Settings.Languages.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.Settings.Languages.Views
{
    [RequireComponent(typeof(Button))]
    public class LanguageSaveView : MonoBehaviour
    {
        private Button _button;
        private LanguageSavePresenter _languageSavePresenter;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.onClick.AddListener(OnClick);

        private void OnDisable() =>
            _button.onClick.AddListener(OnClick);

        public void Construct(LanguageSavePresenter languageSavePresenter) =>
            _languageSavePresenter = languageSavePresenter;

        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);

        private void OnClick()
        {
            _languageSavePresenter.SaveLanguageChanges();
            _languageSavePresenter.RestartScene();
        }
    }
}