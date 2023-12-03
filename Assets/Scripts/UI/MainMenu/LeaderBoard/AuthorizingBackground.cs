using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.LeaderBoard
{
    public class AuthorizingBackground : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnEnable() =>
            _button.onClick.AddListener(LogIn);

        private void OnDisable() =>
            _button.onClick.RemoveListener(LogIn);

        private void Start() =>
            TryShow();

        private void TryShow()
        {
            // TODO Изменить
            if (PlayerAccount.IsAuthorized && PlayerAccount.HasPersonalProfileDataPermission)
                gameObject.SetActive(false);
        }

        public void LogIn()
        {
            PlayerAccount.Authorize();
            PlayerAccount.RequestPersonalProfileDataPermission();
            gameObject.SetActive(false);

            // TODO Вынести в класс переменную
            //UnityEngine.PlayerPrefs.SetInt("AccountAuthorizedIndicator", 1);
        }
    }
}