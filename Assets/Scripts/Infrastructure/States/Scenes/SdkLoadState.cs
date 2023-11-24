using Agava.YandexGames;
using System.Collections;

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

    public void Enter()
    {
        _coroutineRunner.StartCoroutine(InitYandexSDK());
    }

    private IEnumerator InitYandexSDK()
    {
        // yield return YandexGamesSdk.Initialize();
        yield return null;
        LevelsInfo levelsInfo = new LevelsInfo();
        levelsInfo.CurrentDifficult = LevelsProgress.Instance.StartDifficult();
        levelsInfo.SceneName = Levels.MainMenu.ToString();

        _appCore.StateMachine.Enter(typeof(LoadLevelState), levelsInfo);
    }
}