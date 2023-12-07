using Audio;
using UI.MainMenu.Settings.Audio.Presenters;

namespace UI.MainMenu.Settings.Audio.Builders
{
    public class AudioMenuBuilder
    {
        private readonly AudioMenuView _audioMenuView;

        private AudioMenuPresenter _audioMenuPresenter;

        public AudioMenuBuilder(AudioMenuView audioMenuView) => 
            _audioMenuView = audioMenuView;

        public AudioMenuPresenter Build()
        {
            _audioMenuPresenter = new AudioMenuPresenter
            (
                gameAudioData: _audioMenuView.GameAudioData,
                effectsView: _audioMenuView.EffectsView,
                musicView: _audioMenuView.MusicView
            );

            _audioMenuView.AllAudioView.Construct(_audioMenuPresenter);
            _audioMenuView.EffectsView.Construct(_audioMenuPresenter);
            _audioMenuView.MusicView.Construct(_audioMenuPresenter);

            return _audioMenuPresenter;
        }
    }
}