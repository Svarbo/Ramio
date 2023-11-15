using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Data;
using Infrastructure.Core;
using Infrastructure.Factories;
using UI.MainMenu;
using UI.MainMenu.Factories;
using UI.MainMenu.LevelMenu;
using UI.MainMenu.LevelMenu.Builders;
using UI.MainMenu.LevelMenu.Views.Levels;
using UI.MainMenu.MenuSwitcher;
using UI.MainMenu.Models;
using UI.MainMenu.Presenters;
using UI.MainMenu.Settings.Audio.Presenters;
using UI.MainMenu.Settings.Languages.Presenters;
using UI.MainMenu.Views.Levels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States.Scenes
{
    public class MainMenuState : IState
    {
        private readonly AppCore _appCore;
        private readonly ICoroutineRunner _coroutineRunner;
        private DifficultChooserPresenter _difficultChooserPresenter;
        private LevelChooserPresenter _levelChooserPresenter;
        private ButtonStartGamePresenter _buttonStartGamePresenter;
        private MenuSwitcherView _menuSwitcherView;
        private GameAudioData _gameAudioData;
        private LanguagePresenter _languagePresenter;
        private DifficultBuilder _difficultBuilder;
        private LevelChooserBuilder _levelChooserBuilder;
        private ButtonStartGameBuilder _buttonStartGameBuilder;

        public MainMenuState(AppCore appCore, ICoroutineRunner coroutineRunner)
        {
            _appCore = appCore;
            _coroutineRunner = coroutineRunner;
        }

        public void FixedUpdate(float deltaTime)
        {
        }

        public void LateUpdate(float deltaTime)
        {
        }

        public void Update(float deltaTime)
        {
        }

        public void Exit()
        {
        }

        public void Enter() =>
            _coroutineRunner.StartCoroutine(LoadScene());

        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator LoadScene()
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu");

            while (asyncOperation.isDone == false)
                yield return null;

            // TODO Fill UserInfo

            #region Fill UserInfo

            //UserInfo userInfo = abstractFactory.Load<UserInfo>("");
            //userInfo.IsMobile = Agava.WebUtility.Device.IsMobile;

            #endregion

            MainMenuViewFactory mainMenuViewFactory = new MainMenuViewFactory();
            MainMenuView mainMenuView = mainMenuViewFactory.Create();

            #region LevelMenuBuilders
            LevelsInfo levelsInfo = new LevelsInfo();

            _buttonStartGameBuilder = new ButtonStartGameBuilder(levelsInfo, mainMenuView.LevelMenuView.ButtonStartGame, _appCore);
            _buttonStartGamePresenter = _buttonStartGameBuilder.Build();

            _levelChooserBuilder = new LevelChooserBuilder(mainMenuView.LevelMenuView, levelsInfo);
            _levelChooserPresenter = _levelChooserBuilder.Build();
            
            _difficultBuilder = new DifficultBuilder(_levelChooserPresenter, levelsInfo, mainMenuView.LevelMenuView);
            _difficultChooserPresenter = _difficultBuilder.Build();
            #endregion

            #region SettingsFactory

            #region Audio

            _gameAudioData = mainMenuView.SettingsView.AudioMenuView.GameAudioData;
            
            AudioMenuPresenter audioMenuPresenter = new AudioMenuPresenter
            (
                gameAudioData: _gameAudioData,
                effectsView: mainMenuView.SettingsView.AudioMenuView.EffectsView,
                musicView: mainMenuView.SettingsView.AudioMenuView.MusicView
            );
            
            mainMenuView.SettingsView.AudioMenuView.AllAudioView.Construct(audioMenuPresenter);
            mainMenuView.SettingsView.AudioMenuView.EffectsView.Construct(audioMenuPresenter);
            mainMenuView.SettingsView.AudioMenuView.MusicView.Construct(audioMenuPresenter);

            #endregion

            #region Language

            _languagePresenter = new LanguagePresenter
            (
                mainMenuView.SettingsView.LanguagesMainMenuView.LanguageRUView,
                mainMenuView.SettingsView.LanguagesMainMenuView.LanguageENView,
                mainMenuView.SettingsView.LanguagesMainMenuView.LanguageTRView
            );

            #endregion

            #endregion
        }
    }
}
