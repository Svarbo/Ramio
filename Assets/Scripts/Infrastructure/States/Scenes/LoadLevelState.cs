using System.Collections;
using Infrastructure.Core;
using UI.MainMenu.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States.Scenes
{
    public class LoadLevelState : IPayloadState<LevelsInfo>
    {
        private readonly AppCore _appCore;
        private readonly ICoroutineRunner _coroutineRunner;

        public LoadLevelState(AppCore appCore, ICoroutineRunner coroutineRunner)
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

        public void Enter(LevelsInfo levelsInfo)
        {
            _coroutineRunner.StartCoroutine(LoadLevel(levelsInfo));
        }

        private IEnumerator LoadLevel(LevelsInfo levelsInfo)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelsInfo.SceneName);
            
            while (asyncOperation.isDone == false)
                yield return null;
            
            _appCore.StateMachine.Enter(typeof(GameLoopState), levelsInfo);
        }

        public void Enter()
        {

        }
    }

}