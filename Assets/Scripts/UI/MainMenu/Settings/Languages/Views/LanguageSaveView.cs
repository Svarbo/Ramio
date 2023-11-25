using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LanguageSaveView : MonoBehaviour
{
    private Button _button;
    private LanguageSavePresenter _languageSavePresenter;

    private void Awake() => 
        _button = GetComponent<Button>();

    private void OnEnable() => 
        _button.onClick.AddListener(OnClicked);

    private void OnDisable() => 
        _button.onClick.AddListener(OnClicked);

    public void Construct(LanguageSavePresenter languageSavePresenter) => 
        _languageSavePresenter = languageSavePresenter;

    public void Show() =>
        gameObject.SetActive(true);

    public void Hide() =>
        gameObject.SetActive(false);

    private void OnClicked()
    {
        _languageSavePresenter.SaveLanguageChanges();
        _languageSavePresenter.RestartScene();
    }
}