using UnityEngine;
using UnityEngine.UI;

public class HardDifficultView : MonoBehaviour
{
    [SerializeField] private Button _button;
    private DifficultChooserPresenter _difficultChooserPresenter;

    private void OnEnable() =>
        _button.onClick.AddListener(OnClicked);

    private void OnDisable() =>
        _button.onClick.RemoveListener(OnClicked);

    public void Construct(DifficultChooserPresenter difficultChooserPresenter) =>
        _difficultChooserPresenter = difficultChooserPresenter;
    public void Show()
    {
        _button.interactable = true;
    }

    public void Hide()
    {
        _button.interactable = false;
    }

    private void OnClicked() =>
        _difficultChooserPresenter.SetHardDifficult();
}