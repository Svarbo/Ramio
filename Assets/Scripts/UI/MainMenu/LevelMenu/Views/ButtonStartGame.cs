using System;
using UI.MainMenu.Presenters;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStartGame : MonoBehaviour
{
    [SerializeField] private Button _button;

    private ButtonStartGamePresenter _buttonStartGamePresenter;

    private void OnEnable() =>
        _button.onClick.AddListener(OnClick);

    private void OnDisable() =>
        _button.onClick.RemoveListener(OnClick);

    public void Construct(ButtonStartGamePresenter buttonStartGamePresenter) =>
        _buttonStartGamePresenter = buttonStartGamePresenter;
    
    private void OnClick() =>
        _buttonStartGamePresenter.StartGame();
}