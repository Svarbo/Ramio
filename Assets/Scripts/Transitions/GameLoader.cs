using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    private const int LevelsCount = 4;

    [SerializeField] private SceneSwitcher _sceneSwitcher;

    private int _currentLevelIndex;

    private void OnEnable()
    {
        _sceneSwitcher.IsReadyToLoadMainMenu += LoadMainMenu;
        _sceneSwitcher.IsReadyToLoadLevel += LoadLevel;
    }

    private void OnDisable()
    {
        _sceneSwitcher.IsReadyToLoadMainMenu -= LoadMainMenu;
        _sceneSwitcher.IsReadyToLoadLevel -= LoadLevel;
    }
    public void SetCurrentLevelIndex(int levelIndex)
    {
        _currentLevelIndex = levelIndex;
    }

    public void TrySwitchToNextLevel()
    {
        if (_currentLevelIndex + 1 < LevelsCount)
            _currentLevelIndex++;
    }

    private void LoadMainMenu()
    {
        MainMenu.Load();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene($"Level{_currentLevelIndex}");
    }
}