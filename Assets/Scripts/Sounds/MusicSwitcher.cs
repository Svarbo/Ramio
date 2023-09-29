using UnityEngine;
using UnityEngine.UI;

public class MusicSwitcher : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _slider;
    [SerializeField] private Sounds _soundsVolume;

    private float _volumeValue;

    private void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat("Volume");

        SetSliderValue(_volumeValue);
        SetToggleStatus(_volumeValue);
    }

    private void SetToggleStatus(float volumeValue)
    {
        if (volumeValue == 0)
            _toggle.isOn = true;
        else
            _toggle.isOn = false;
    }

    private void SetSliderValue(float volumeValue)
    {
        _slider.value = volumeValue;
    }

    public void ChangeVolume()
    {
        float volumeValue = _slider.value;

        PlayerPrefs.SetFloat("Volume", volumeValue);

        SetToggleStatus(volumeValue);

        _soundsVolume.SetVolumeValues();
    }

    public void SwitchMusicActivity()
    {
        if (_toggle.isOn)
            PlayerPrefs.SetFloat("Volume", 0);
        else
            PlayerPrefs.SetFloat("Volume", _volumeValue);

        _soundsVolume.SetVolumeValues();
    }
}