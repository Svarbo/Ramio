using System.Collections;
using Data;
using Infrastructure.Core;
using Transitions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States.Scenes
{
    public class LoadLevelState : IPayloadState<LevelsInfo>
    {
        private readonly AppCore _appCore;
        private readonly ICoroutineRunner _coroutineRunner;

        private Fader _fader;
        private LevelsInfo _levelsInfo;

        public LoadLevelState(AppCore appCore, ICoroutineRunner coroutineRunner, Fader fader)
        {
            _fader = fader;
            _appCore = appCore;
            _coroutineRunner = coroutineRunner;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
        }

        public void Enter(LevelsInfo levelsInfo)
        {
            _levelsInfo = levelsInfo;
            _fader.FadeIn(LoadLevel);
        }

        private void LoadLevel() =>
            _coroutineRunner.StartCoroutine(LoadLevelCoroutine(_levelsInfo));

        private IEnumerator LoadLevelCoroutine(LevelsInfo levelsInfo)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelsInfo.SceneName);

            while (asyncOperation.isDone == false)
                yield return null;

            if (levelsInfo.SceneName == Levels.MainMenu.ToString())
                _appCore.StateMachine.Enter(typeof(MainMenuState), levelsInfo);
            else
                _appCore.StateMachine.Enter(typeof(GameLoopState), levelsInfo);

            _fader.FadeOut();
        }
    }
}