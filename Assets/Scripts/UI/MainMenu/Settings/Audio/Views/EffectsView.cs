using UI.MainMenu.Settings.Audio.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.Settings.Audio.Views
{
    public class EffectsView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private AudioMenuPresenter _allAudioPresenter;

        public float Value => _slider.value;

        private void OnEnable() =>
            _slider.onValueChanged.AddListener(OnValueChanged);

        private void OnDisable() =>
            _slider.onValueChanged.RemoveListener(OnValueChanged);

        public void Construct(AudioMenuPresenter allAudioPresenter) =>
            _allAudioPresenter = allAudioPresenter;

        public void ChangeValue(float newValue)
        {
            float value = Mathf.Clamp01(newValue);
            _slider.value = value;
        }

        private void OnValueChanged(float newVolume) =>
            _allAudioPresenter.SetEffectsVolume(newVolume);
    }
}