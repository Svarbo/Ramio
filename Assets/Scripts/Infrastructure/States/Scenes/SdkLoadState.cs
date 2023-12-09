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
            // TODO
            // YandexGamesSdk.CallbackLogging = true;
            while (YandexGamesSdk.IsInitialized == false)
            {
                YandexGamesSdk.Initialize();
                yield return null; 
            }

            onSuccessCallback?.Invoke();
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