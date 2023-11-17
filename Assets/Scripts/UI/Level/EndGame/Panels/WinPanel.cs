using System;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button _buttonGoToNextLevel;
    [SerializeField] private Button _buttonGoMenu;
    private StateMachine _stateMachine;

    public event Action GoToNextLevel;
    public event Action GoMenu;

    private void OnEnable()
    {
        _buttonGoToNextLevel.onClick.AddListener(OnClicked1);
        _buttonGoMenu.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _buttonGoToNextLevel.onClick.RemoveListener(OnClicked1);
        _buttonGoMenu.onClick.RemoveListener(OnClicked);
    }
        
    public void Construct(StateMachine stateMachine) =>
        _stateMachine = stateMachine;

    private void OnClicked1()
    {
        _stateMachine.Enter(typeof(LoadLevelState));
    }

    private void OnClicked()
    {
        _stateMachine.Enter(typeof(MainMenuState));
    }
}