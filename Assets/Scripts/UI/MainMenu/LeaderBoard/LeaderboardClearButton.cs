using System;
using Agava.YandexGames;
using ConstantValues;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.Leaderboard
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
            Agava.YandexGames.Leaderboard.GetPlayerEntry(leaderboardName: LeaderboardsNames.EasyLeaderboardName,
				onSuccessCallback: _ =>
				{
					_ = null;
				});
			
			LevelsProgress.Instance.ClearAllProgress();
		}
	}
}