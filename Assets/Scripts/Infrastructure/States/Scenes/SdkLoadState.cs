public class SdkLoadState : IState
{
    private readonly AppCore _appCore;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly StateMachine _stateMachine;

    public SdkLoadState(AppCore appCore)
    {
        _appCore = appCore;
        // _coroutineRunner = coroutineRunner;
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

    public void Enter()
    {
        //_coroutineRunner.StartCoroutine(InitYandexSDK());


        _appCore.StateMachine.Enter(typeof(MainMenuState));
    }

    // private IEnumerator InitYandexSDK()
    // {
    //     // yield return YandexGamesSdk.Initialize();
    //     
    // }
}