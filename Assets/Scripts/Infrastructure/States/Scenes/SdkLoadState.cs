using System;
using Data;
using Infrastructure.Core;
using System.Collections;
using Agava.YandexGames;
using UnityEngine;

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
            // TODO Ж: так, не понял, что ты хотел чтобы я сделал, ну если последняя строка должна быть раскоменчена, то нужно сначала создать объект, чтобы не создавать его каждый кадр
            YandexGamesSdk.CallbackLogging = true;
            yield return YandexGamesSdk.Initialize(onSuccessCallback);
            //yield return new WaitForSeconds(1);
        }

        private void LoadMainMenuScene()
        {
            LevelsInfo levelsInfo = new LevelsInfo();
            levelsInfo.CurrentDifficult = LevelsProgress.Instance.GetStartDifficult();
            levelsInfo.SceneName = Levels.MainMenu.ToString();

            _appCore.StateMachine.Enter(typeof(LoadLevelState), levelsInfo);
        }
    }
}