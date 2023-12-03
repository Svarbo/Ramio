using System;
using Agava.YandexGames;
using ConstantValues;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.LeaderBoard
{
	public class LeaderboardClearButton : MonoBehaviour
	{
		[SerializeField] private Button _button;

		private void OnEnable() =>
			_button.onClick.AddListener(Clear);

		private void OnDisable() =>
			_button.onClick.RemoveListener(Clear);

		private void Clear()
		{
			Leaderboard.GetPlayerEntry(leaderboardName: LeaderboardsNames.EasyLeaderboardName,
				onSuccessCallback: _ =>
				{
					_ = null;
				});
			
			LevelsProgress.Instance.ClearAllProgress();
		}
	}
}