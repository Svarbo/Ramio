using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Referee : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";
    private const string LastLevelName = "Level3";

    [SerializeField] private Player _player;
    [SerializeField] private PlayerCanvasDrawer _playerCanvasDrawer;

    private void OnEnable()
    {
        _player.PlayerDied += DeclairLose;
    }

    private void OnDisable()
    {
        _player.PlayerDied -= DeclairLose;
    }

    public void DeclairWin()
    {
        _playerCanvasDrawer.DrawWinPanel(_player.FruitsCount);
        TrySetPlayerResult();
    }

    private void DeclairLose()
    {
        _playerCanvasDrawer.DrawDefeatPanel();
    }

    private void TrySetPlayerResult()
    {
        string currentLevelName = SceneManager.GetActiveScene().name;

        if (LastLevelName == currentLevelName)
        {
            int playerScore = _player.FruitsCount;

            Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
            {
                if (playerScore < result.score)
                    Leaderboard.SetScore(LeaderboardName, playerScore);
            });
        }
    }
}