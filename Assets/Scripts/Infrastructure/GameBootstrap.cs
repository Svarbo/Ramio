using UnityEngine;

public class GameBootstrap : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private Fader _fader;
    [SerializeField] private GameAudioData _gameAudioData;
    private float _musicVolume;

    public AppCore AppCore { get; private set; }

    private void Awake()
    {
        _musicVolume = _gameAudioData.Music;
        
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

    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            _gameAudioData.SetMusicVolume(_musicVolume);
            Time.timeScale = 1f;
        }
        else
        {
            _musicVolume = _gameAudioData.Music;
            _gameAudioData.SetMusicVolume(0);
            Time.timeScale = 0f;
        }
    }
}