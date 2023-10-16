using System.Collections;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly StateMachine _stateMachine;
        private ICoroutineRunner _coroutineRunner;

        public BootstrapState(StateMachine stateMachine, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter() =>
            _coroutineRunner.StartCoroutine(InitializeYandexGamesSdkCoroutine());

        private IEnumerator InitializeYandexGamesSdkCoroutine()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            yield return YandexGamesSdk.Initialize( () => SuccesInitialize());
            // if (PlayerAccount.IsAuthorized == false)
            //     PlayerAccount.StartAuthorizationPolling(1500);
#endif
             _stateMachine.Enter<SceneLoaderState, string>("MainMenu");
             yield return null;
        }

        private void SuccesInitialize()
        {
#if UNITY_WEBGL
            SetLanguage();
#endif
            _stateMachine.Enter<SceneLoaderState, string>("MainMenu");
        }

        private static void SetLanguage()
        {
            LanguageDefiner languageDefiner = new LanguageDefiner();
            languageDefiner.TryDefineLanguage();
        }


        public void Exit()
        {

        }

    }

}