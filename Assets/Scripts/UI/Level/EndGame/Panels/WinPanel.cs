using System;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button _buttonGoToNextLevel;
    [SerializeField] private Button _buttonGoMenu;
    private StateMachine _stateMachine;
    private LevelsInfo _levelsInfo;

    private void OnEnable()
    {
        _buttonGoToNextLevel.onClick.AddListener(GoToNextLevel);
        _buttonGoMenu.onClick.AddListener(GoMenu);
    }

    private void OnDisable()
    {
        _buttonGoToNextLevel.onClick.RemoveListener(GoToNextLevel);
        _buttonGoMenu.onClick.RemoveListener(GoMenu);
    }
        
    public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo)
    {
        _levelsInfo = levelsInfo;
        _stateMachine = stateMachine;
    }

    private void GoToNextLevel() =>
        _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);

    private void GoMenu() =>
        _stateMachine.Enter(typeof(MainMenuState));
}