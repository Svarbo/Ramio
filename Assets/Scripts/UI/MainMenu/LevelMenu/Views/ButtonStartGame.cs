using System;
using UI.MainMenu.Presenters;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStartGame : MonoBehaviour
{
    [SerializeField] private Button _button;

    private ButtonStartGamePresenter _buttonStartGamePresenter;

    private void Awake() =>
        Hide();

    private void OnEnable() =>
        _button.onClick.AddListener(OnClick);

    private void OnDisable() =>
        _button.onClick.RemoveListener(OnClick);

    public void Construct(ButtonStartGamePresenter buttonStartGamePresenter) =>
        _buttonStartGamePresenter = buttonStartGamePresenter;
    
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
    
    private void OnClick() =>
        _buttonStartGamePresenter.StartGame();
}