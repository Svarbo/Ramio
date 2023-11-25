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

    public void DeclairWin()
    {
        _playerCanvasDrawer.DrawWinPanel(_player.FruitsCount);
        //TODO ВКлючить
        //TrySetPlayerResult();
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
            int playerScore = _player.AttemptsCount;

            Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
            {
                if (playerScore < result.score)
                    Leaderboard.SetScore(LeaderboardName, playerScore);
            });
        }
    }
}