using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
    public class SceneLoaderState : IPayloadState<string>
    {
        private readonly StateMachine _stateMachine;
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoaderState(StateMachine stateMachine, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter(string sceneName)
        {
            AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(sceneName);
            _coroutineRunner.StartCoroutine(LoadSceneCoroutine(sceneAsync));
        }

        private IEnumerator LoadSceneCoroutine(AsyncOperation sceneAsync)
        {
            while (sceneAsync.isDone == false)
                yield return null;

            _stateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {

        }
    }

}