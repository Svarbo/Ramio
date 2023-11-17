using UnityEngine;
using UnityEngine.UI;

public class EasyDifficultViewButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSource;

    private DifficultChooserPresenter _difficultChooserPresenter;

    private void OnDisable() =>
        _button.onClick.RemoveListener(OnClicked);

    private void OnEnable() =>
        _button.onClick.AddListener(OnClicked);

    public void Construct(DifficultChooserPresenter difficultChooserPresenter) =>
        _difficultChooserPresenter = difficultChooserPresenter;

    private void OnClicked()
    {
        _audioSource.Play();
        _difficultChooserPresenter.SetEasyDifficult();
    }
}