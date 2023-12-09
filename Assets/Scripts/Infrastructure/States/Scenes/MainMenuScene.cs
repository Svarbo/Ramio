using Agava.YandexGames;
using UI.MainMenu.Settings.Audio.Presenters;
using Audio;
using Data;
using Infrastructure.Core;
using Infrastructure.States;
using Localization;
using UI.MainMenu.Factories;
using UI.MainMenu.LevelMenu.Difficults.Presenters;
using UI.MainMenu.LevelMenu.LevelChoosers;
using UI.MainMenu.Menu;
using UI.MainMenu.Settings.Audio.Builders;
using UI.MainMenu.Settings.Languages;
using UI.MainMenu.Settings.Languages.Presenters;

namespace Infrastructure.States.Scenes
{
    public class MainMenuState : IPayloadState<LevelsInfo>
    {
        private readonly AppCore _appCore;
        private DifficultChooserPresenter _difficultChooserPresenter;
        private LevelChooserPresenter _levelChooserPresenter;
        private GameAudioData _gameAudioData;
        private LanguageSavePresenter _languageSavePresenter;
        private DifficultBuilder _difficultBuilder;
        private LevelChooserBuilder _levelChooserBuilder;
        private LevelsInfo _levelsInfo;
        private LanguageTogglePresenter _languageTogglePresenter;
        private AudioMenuPresenter _audioMenuPresenter;
        private AudioMenuBuilder _audioMenuBuilder;
        private LanguageMenuBuilder _languageMenuBuilder;

        public MainMenuState(AppCore appCore) =>
            _appCore = appCore;

        public void Exit()
        {
        }

        public void Enter(LevelsInfo levelsInfo)
        {
            _levelsInfo = levelsInfo;
            LoadScene();
        }

        public void Enter()
        {
        }

        private void LoadScene()
        {
            MainMenuViewFactory mainMenuViewFactory = new MainMenuViewFactory();
            MainMenuView mainMenuView = mainMenuViewFactory.Create();
            // TODO при билде раскоментить 
            _levelsInfo.IsMobile = Agava.WebUtility.Device.IsMobile;
            //_levelsInfo.IsMobile = false;

            _levelChooserBuilder = new LevelChooserBuilder(mainMenuView.LevelMenuView, _levelsInfo, _appCore.StateMachine);
            _levelChooserPresenter = _levelChooserBuilder.Build();
            
            _difficultBuilder = new DifficultBuilder(_levelChooserPresenter, _levelsInfo, mainMenuView.LevelMenuView.DifficultChooserView);
            _difficultChooserPresenter = _difficultBuilder.Build();
            
            _audioMenuBuilder = new AudioMenuBuilder(mainMenuView.SettingsView.AudioMenuView);
            _audioMenuPresenter = _audioMenuBuilder.Build();

            _languageMenuBuilder = new LanguageMenuBuilder(mainMenuView.SettingsView.LanguageChanger, _appCore.StateMachine, _levelsInfo);
            _languageSavePresenter = _languageMenuBuilder.BuildLanguageSavePresenter();
            _languageTogglePresenter = _languageMenuBuilder.BuildLanguageTogglePresenter();
        }
    }
}