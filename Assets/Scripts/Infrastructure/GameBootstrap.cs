using System.Collections;
using UnityEngine;

public class GameBootstrap : MonoBehaviour, ICoroutineRunner
{
    public AppCore AppCore { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (AppCore is null)
            AppCore = new AppCore(this);
    }

    private void Update() => 
        AppCore.StateMachine.Update(Time.deltaTime);

    private void FixedUpdate() => 
        AppCore.StateMachine.FixedUpdate(Time.fixedDeltaTime);

    private void LateUpdate() => 
        AppCore.StateMachine.Update(Time.deltaTime);
}

public interface ICoroutineRunner
{
    Coroutine StartCoroutine(IEnumerator coroutine);

    void StopCoroutine(Coroutine coroutine);
}