using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenu;
    [SerializeField] private Canvas _levelMenu;
    [SerializeField] private Canvas _settings;
    [SerializeField] private Canvas _leaderboard;
    [SerializeField] private Canvas _authors;

    public void EnableMainMenu()
    {
        _mainMenu.gameObject.SetActive(true);

        _levelMenu.gameObject.SetActive(false);
        _settings.gameObject.SetActive(false);
        _leaderboard.gameObject.SetActive(false);
    }

    public void EnableLevelMenu()
    {
        _levelMenu.gameObject.SetActive(true);
        _mainMenu.gameObject.SetActive(false);
    }

    public void EnableSettings()
    {
        _settings.gameObject.SetActive(true);
        _mainMenu.gameObject.SetActive(false);
    }

    public void EnableLeaderboard()
    {
        _leaderboard.gameObject.SetActive(true);
        _mainMenu.gameObject.SetActive(false);
    }

    public void EnableAuthorsMenu()
    {
        _authors.gameObject.SetActive(true);
        _mainMenu.gameObject.SetActive(false);
    }
}