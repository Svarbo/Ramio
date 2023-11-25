using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Referee : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard1";
    private const string LastLevelName = "Level3";

    [SerializeField] private Player _player;
    [SerializeField] private PlayerCanvasDrawer _playerCanvasDrawer;

    private void OnEnable() =>
        _player.PlayerDesappeared += DeclairLose;

    private void OnDisable() =>
        _player.PlayerDesappeared -= DeclairLose;

    public bool IsLastLevel()
    {
        string currentLevelName = SceneManager.GetActiveScene().name;
        return LastLevelName == currentLevelName;
    }

    public void ShowWinPanel() =>
        _playerCanvasDrawer.DrawWinPanel(_player.FruitsCount);

    public void ShowFinishPanel()
    {
        _playerCanvasDrawer.DrawFinishPanel();
        //TODO ВКлючить
        //TrySetPlayerResult();
    }

    private void DeclairLose() =>
        _playerCanvasDrawer.DrawDefeatPanel();

    private void TrySetPlayerResult()
    {
        int playerScore = _player.AttemptsCount;

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (playerScore < result.score)
                Leaderboard.SetScore(LeaderboardName, playerScore);
        });
    }
}