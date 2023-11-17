using UnityEngine;

public class AudioMenuPresenter
{
    private readonly GameAudioData _gameAudioData;
    private readonly EffectsView _effectsView;
    private readonly MusicView _musicView;

    public AudioMenuPresenter(GameAudioData gameAudioData, EffectsView effectsView, MusicView musicView)
    {
        _gameAudioData = gameAudioData;
        _effectsView = effectsView;
        _musicView = musicView;

        _effectsView.ChangeValue(_gameAudioData.Effects);
        _musicView.ChangeValue(_gameAudioData.Music);
    }

    public void SetAllVolume(float newVolume)
    {
        float volume = Mathf.Clamp01(newVolume);

        _effectsView.ChangeValue(volume);
        _musicView.ChangeValue(volume);

        _gameAudioData.SetEffectsVolume(volume);
        _gameAudioData.SetMusicVolume(volume);
    }

    public void SetEffectsVolume(float newVolume)
    {
        float volume = Mathf.Clamp01(newVolume);
        _gameAudioData.SetEffectsVolume(volume);
    }

    public void SetMusicVolume(float newVolume)
    {
        float volume = Mathf.Clamp01(newVolume);
        _gameAudioData.SetMusicVolume(volume);
    }
}