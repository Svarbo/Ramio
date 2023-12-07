using Data;
using Infrastructure.StateMachines;
using Localization;
using UI.MainMenu.Settings.Audio.Presenters;
using UI.MainMenu.Settings.Languages.Presenters;

namespace UI.MainMenu.Settings.Languages
{
    public class LanguageMenuBuilder
    {
        private readonly LanguageChanger _languageChanger;
        private readonly StateMachine _stateMachine;
        private readonly LevelsInfo _levelsInfo;

        private LanguageTogglePresenter _languageTogglePresenter;
        private LanguageSavePresenter _languageSavePresenter;

        public LanguageMenuBuilder(LanguageChanger languageChanger, StateMachine stateMachine, LevelsInfo levelsInfo)
        {
            _languageChanger = languageChanger;
            _stateMachine = stateMachine;
            _levelsInfo = levelsInfo;
        }

        public LanguageTogglePresenter BuildLanguageTogglePresenter()
        {
            _languageTogglePresenter = new LanguageTogglePresenter(_languageChanger.LanguageSaveView);
            _languageChanger.LanguageToggleRU.Construct(_languageTogglePresenter);
            _languageChanger.LanguageToggleEN.Construct(_languageTogglePresenter);
            _languageChanger.LanguageToggleTR.Construct(_languageTogglePresenter);

            return _languageTogglePresenter;
        }
        
        public LanguageSavePresenter BuildLanguageSavePresenter()
        {
            _languageSavePresenter = new LanguageSavePresenter(_stateMachine, _levelsInfo, _languageChanger, _languageChanger.LanguageSaveView);
            _languageChanger.LanguageSaveView.Construct(_languageSavePresenter);

            return _languageSavePresenter;
        }
    }
}