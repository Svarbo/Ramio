using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private GameBootstrap _gameBootstrap;
    private LevelBootstrap _levelBootstrap;

    private void Start() =>
        _gameBootstrap = FindObjectOfType<GameBootstrap>();

    private void OnEnable() =>
        _button.onClick.AddListener(OpenMainMenu);

    private void OnDisable() =>
        _button.onClick.RemoveListener(OpenMainMenu);

    private void OpenMainMenu()
    {
        LevelsInfo levelsInfo = FindObjectOfType<LevelBootstrap>().LevelsInfo;
        levelsInfo.SceneName = Levels.MainMenu.ToString();
        _gameBootstrap.AppCore.StateMachine.Enter(typeof(LoadLevelState), levelsInfo);
    }
}