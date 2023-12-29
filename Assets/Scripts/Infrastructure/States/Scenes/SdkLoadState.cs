using System;
using System.Collections;
using Agava.YandexGames;
using Data;
using Infrastructure.Core;
using Localization;

namespace Infrastructure.States.Scenes
{
    public class SdkLoadState : IState
    {
        private readonly AppCore _appCore;
        private readonly ICoroutineRunner _coroutineRunner;

        public SdkLoadState(AppCore appCore, ICoroutineRunner coroutineRunner)
        {
            _appCore = appCore;
            _coroutineRunner = coroutineRunner;
        }

        public void Exit()
        {
        }

        public void Enter() =>
            _coroutineRunner.StartCoroutine(LoadSdkCoroutine(LoadMainMenuScene));

        private IEnumerator LoadSdkCoroutine(Action onSuccessCallback = null)
        {
            YandexGamesSdk.CallbackLogging = true;
            yield return YandexGamesSdk.Initialize(onSuccessCallback);
        }

        private void LoadMainMenuScene()
        {
            LevelsInfo levelsInfo = new LevelsInfo();
            levelsInfo.CurrentDifficult = LevelsProgress.Instance.GetStartDifficult();
            levelsInfo.SceneName = Levels.MainMenu.ToString();
            LanguageDefiner languageDefiner = new LanguageDefiner();
            languageDefiner.DefineLanguage();

            _appCore.StateMachine.Enter(typeof(LoadLevelState), levelsInfo);
        }
    }
}