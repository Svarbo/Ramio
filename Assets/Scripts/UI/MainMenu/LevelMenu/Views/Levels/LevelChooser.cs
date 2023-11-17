using UnityEngine;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour
{
    [SerializeField] private Levels _level;
    [SerializeField] private Button _button;

    private LevelChooserPresenter _levelChooserPresenter;

    private void Awake() =>
        Hide();

    private void OnEnable() =>
        _button.onClick.AddListener(OnClick);

    private void OnDisable() =>
        _button.onClick.RemoveListener(OnClick);

    public void Construct(LevelChooserPresenter levelChooserPresenter) =>
        _levelChooserPresenter = levelChooserPresenter;

    public void Hide()
    {
        _button.interactable = false;
        _button.GetComponent<Image>().color = new Color(0, 0, 0);
    }

    public void Show()
    {
        _button.GetComponent<Image>().color = new Color(0, 255, 32);
        _button.interactable = true;
    }

    private void OnClick()
    {
        _levelChooserPresenter.ActivateButtonToStartGame();
        _levelChooserPresenter.SetLevelName(_level.ToString());
    }
}