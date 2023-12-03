using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.LeaderBoard
{
	public class AuthorizingBackground : MonoBehaviour
	{
		[SerializeField] private Button _button;
		[SerializeField] private GameObject _panel;

		private void OnEnable() =>
			TryShow();

		private void OnDisable() =>
			_button.onClick.RemoveListener(LogIn);

		private void TryShow()
		{
			// TODO Изменить
			if (PlayerAccount.IsAuthorized && PlayerAccount.HasPersonalProfileDataPermission)
				LogIn();
			else
				_button.onClick.AddListener(LogIn);
		}

		public void LogIn()
		{
			PlayerAccount.Authorize();
			PlayerAccount.RequestPersonalProfileDataPermission();
			_panel.SetActive(true);
			gameObject.SetActive(false);

			// TODO Вынести в класс переменную
			//UnityEngine.PlayerPrefs.SetInt("AccountAuthorizedIndicator", 1);
		}
	}
}