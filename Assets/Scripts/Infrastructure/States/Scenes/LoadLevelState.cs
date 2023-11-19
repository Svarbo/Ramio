using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        _appCore.StateMachine.Enter(typeof(GameLoopState), levelsInfo);

        _fader.FadeOut();
    }
}