using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.Leaderboard
{
    public class AuthorizingBackground : MonoBehaviour
    {
        [SerializeField] private Button _authorizeButton;
        [SerializeField] private LeaderboardView _leaderboardView;

        private void OnEnable() =>
            TryShow();

        private void OnDisable()
        {
            _authorizeButton.onClick.RemoveListener(ShowLeaderboard);
            _authorizeButton.onClick.RemoveListener(LogIn);
            _authorizeButton.onClick.RemoveListener(GetPermission);
        }

        private void TryShow()
        {
            if (PlayerAccount.IsAuthorized && PlayerAccount.HasPersonalProfileDataPermission)
            {
                ShowLeaderboard();
            }
            else
            {
                _authorizeButton.onClick.AddListener(ShowLeaderboard);

                if (PlayerAccount.IsAuthorized == false)
                    _authorizeButton.onClick.AddListener(LogIn);

                if (PlayerAccount.HasPersonalProfileDataPermission == false)
                    _authorizeButton.onClick.AddListener(GetPermission);
            }
        }

        private void LogIn() =>
            PlayerAccount.Authorize();

        private void GetPermission() =>
            PlayerAccount.RequestPersonalProfileDataPermission();

        private void ShowLeaderboard()
        {
            _leaderboardView.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}