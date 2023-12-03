using Agava.YandexGames;
using Data;
using Data.Difficults;
using Player;
using UI.Level.EndGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Referee : MonoBehaviour
{
    private const string LastLevelName = "Level3";

    [SerializeField] private MainHero _player;
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

    public void ShowFinishPanel() =>
        _playerCanvasDrawer.DrawFinishPanel();

    private void DeclairLose()
    {
        _playerCanvasDrawer.DrawDefeatPanel();
        AddPlayerToLeaderboard();
        //SetPlayerResult();
    }

    private void SetPlayerResult()
    {
        IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(_playerCanvasDrawer._levelsInfo.CurrentDifficult);
        int allCountTry = difficult.GetAllCountTry();

        Leaderboard.SetScore
        (
            leaderboardName: difficult.GetType().ToString(),
            score: allCountTry
        );
    }


    private void AddPlayerToLeaderboard()
    {
        IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(_playerCanvasDrawer._levelsInfo.CurrentDifficult);
        int playerScore = difficult.GetAllCountTry();

        // TODO не записывать неавторизированных пользователей
        // Leaderboard.GetPlayerEntry(
        //     leaderboardName: difficult.GetType().ToString(),
        //     onSuccessCallback: (result) => response = result,
        //     onErrorCallback: (result) => Debug.LogError($"[YandexLeaderboard] Error in receiving player records: {result}"));

        Leaderboard.SetScore(difficult.GetType().ToString(), playerScore);
    }
}