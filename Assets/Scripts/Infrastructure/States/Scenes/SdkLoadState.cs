using System;
using Infrastructure;
using Infrastructure.States;
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

        public void FixedUpdate(float deltaTime)
        {
        }

        public void LateUpdate(float deltaTime)
        {
        }

        public void Update(float deltaTime)
        {
        }

        public void Enter() =>
            _coroutineRunner.StartCoroutine(LoadSdkCoroutine(LoadMainMenuScene));
        
        private IEnumerator LoadSdkCoroutine(Action onSuccessCallback = null)
        {
            // TODO
            YandexGamesSdk.CallbackLogging = true;
            yield return YandexGamesSdk.Initialize(() => onSuccessCallback?.Invoke());
            // yield return null;
            // LoadMainMenuScene();
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