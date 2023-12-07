using Data;
using Infrastructure.States.Scenes;
using Localization;
using UI.MainMenu.Settings.Languages.Views;
using StateMachine = Infrastructure.StateMachines.StateMachine;

namespace UI.MainMenu.Settings.Languages.Presenters
{
    public class LanguageSavePresenter
    {
        private readonly StateMachine _stateMachine;
        private readonly LevelsInfo _levelsInfo;
        private readonly LanguageChanger _languageChanger;
        private readonly LanguageSaveView _languageSaveView;

        public LanguageSavePresenter(StateMachine stateMachine, LevelsInfo levelsInfo, LanguageChanger languagesChanger, LanguageSaveView languageSaveView)
        {
            _stateMachine = stateMachine;
            _levelsInfo = levelsInfo;
            _languageChanger = languagesChanger;
            _languageSaveView = languageSaveView;
        }

        public void SaveLanguageChanges()
        {
            _languageChanger.ChangeLanguage();
        }

        public void RestartScene()
        {
            _levelsInfo.SceneName = Levels.MainMenu.ToString();
            _languageSaveView.Hide();
            _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
        }
    }
}