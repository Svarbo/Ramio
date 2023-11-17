using UnityEngine;
using UnityEngine.UI;

public class LanguageView : MonoBehaviour
{
    [SerializeField] private Button _button;

    private LanguagePresenter _languagePresenter;

    private void OnEnable() =>
        _button.onClick.AddListener(OnClicked);

    private void OnDisable() =>
        _button.onClick.RemoveListener(OnClicked);

    public void Construct(LanguagePresenter languagePresenter) =>
        _languagePresenter = languagePresenter;

    private void OnClicked() =>
        _languagePresenter.ChangeLanguage();

    public void SetDisactive()
    {
        //TODO изменить
        gameObject.SetActive(false);
    }
}