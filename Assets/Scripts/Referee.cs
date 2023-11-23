using Agava.YandexGames;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Referee : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";

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
        _playerCanvasDrawer.DrawWinPanel(_player.Score);
        TrySetPlayerResult();
    }

    private void DeclairLose()
    {
        _playerCanvasDrawer.DrawDefeatPanel();
    }

    private void TrySetPlayerResult()
    {
        Array allLevels = Enum.GetValues(typeof(Levels));
        string lastLevelName = allLevels.GetValue(allLevels.Length).ToString();
        string currentLevelName = SceneManager.GetActiveScene().name;

        if (lastLevelName == currentLevelName)
        {
            Debug.Log("Попытка обновления результата");

            int playerScore = _player.Score;

            Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
            {
                if (playerScore < result.score)
                    Leaderboard.SetScore(LeaderboardName, playerScore);
            });
        }
    }
}