using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button _buttonGoToNextLevel;
    [SerializeField] private Button _buttonGoMenu;

    private StateMachine _stateMachine;
    private LevelsInfo _levelsInfo;

    private void OnEnable()
    {
        _buttonGoToNextLevel.onClick.AddListener(LoadNextLevel);
        _buttonGoMenu.onClick.AddListener(LoadMainMenu);
    }

    private void OnDisable()
    {
        _buttonGoToNextLevel.onClick.RemoveListener(LoadNextLevel);
        _buttonGoMenu.onClick.RemoveListener(LoadMainMenu);
    }

    public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo)
    {
        _levelsInfo = levelsInfo;
        _stateMachine = stateMachine;
    }

    private void LoadNextLevel()
    {
        string currentLevelName = SceneManager.GetActiveScene().name;
        string levelName = currentLevelName.Substring(currentLevelName.Length - 1);

        if (int.TryParse(levelName, out int number))
            number++;
        else
            throw new InvalidOperationException(levelName);

        currentLevelName = currentLevelName.Remove(currentLevelName.Length - 1);
        currentLevelName += number.ToString();

        _levelsInfo.SceneName = currentLevelName;
        _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
    }

    private void LoadMainMenu()
    {
        _levelsInfo.SceneName = "MainMenu";
        _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
    }
}