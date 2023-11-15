using UI.MainMenu.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.LevelMenu.Views.Levels
{
    public class LevelChooser : MonoBehaviour
    {
        [SerializeField] private Models.Levels _level;
        [SerializeField] private Button _button;

        private LevelChooserPresenter _levelChooserPresenter;

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnClick);

        public void Construct(LevelChooserPresenter levelChooserPresenter)
        {
            _levelChooserPresenter = levelChooserPresenter;
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _levelChooserPresenter.ActivateButtonToStartGame();
            _levelChooserPresenter.SetLevelName(_level.ToString());
        }
    }
}