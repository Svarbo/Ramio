using UI.MainMenu.Settings.Audio.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.Settings.Audio.Views
{
    public class AllAudioView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private AudioMenuPresenter _allAudioPresenter;

        private void OnEnable() =>
            _slider.onValueChanged.AddListener(OnValueChanged);

        private void OnDisable() =>
            _slider.onValueChanged.RemoveListener(OnValueChanged);

        public void Construct(AudioMenuPresenter allAudioPresenter) =>
            _allAudioPresenter = allAudioPresenter;

        private void OnValueChanged(float newVolume) =>
            _allAudioPresenter.SetAllVolume(newVolume);
    }
}