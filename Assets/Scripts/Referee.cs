using System;
using Agava.YandexGames;
using ConstantValues;
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
	}

	private void AddPlayerToLeaderboard()
	{
		if (PlayerAccount.IsAuthorized == false)
			return;

		IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(_playerCanvasDrawer.LevelsInfo.CurrentDifficult);
		int playerScore = difficult.GetAllCountTry();
		string key;

		if (_playerCanvasDrawer.LevelsInfo.CurrentDifficult == typeof(Easy))
			key = LeaderboardsNames.EasyLeaderboardName;
		else if (_playerCanvasDrawer.LevelsInfo.CurrentDifficult == typeof(Medium))
			key = LeaderboardsNames.MediumLeaderboardName;
		else
			key = LeaderboardsNames.HardLeaderboardName;
		
		// TODO не записывать неавторизированных пользователей
		Leaderboard.GetPlayerEntry(leaderboardName: key,
			onSuccessCallback: _ =>
			{
				Leaderboard.SetScore(key, playerScore);
			});
	}
}