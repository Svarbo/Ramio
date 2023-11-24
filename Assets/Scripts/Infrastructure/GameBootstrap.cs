using UnityEngine;

public class GameBootstrap : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private Fader _fader;
    public AppCore AppCore { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (AppCore is null)
            AppCore = new AppCore(this, _fader);
    }

    private void Update() => 
        AppCore.StateMachine.Update(Time.deltaTime);

    private void FixedUpdate() => 
        AppCore.StateMachine.FixedUpdate(Time.fixedDeltaTime);

    private void LateUpdate() => 
        AppCore.StateMachine.Update(Time.deltaTime);
}