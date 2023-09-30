using Agava.YandexGames;
using UnityEngine;

public class AuthorizingBackground : MonoBehaviour
{
    private void Start()
    {
        TryShow();
    }

    private void TryShow()
    {
        if (PlayerAccount.IsAuthorized == true)
            gameObject.SetActive(false);
    }

    public void LogIn()
    {
        PlayerAccount.Authorize();
        gameObject.SetActive(false);

        UnityEngine.PlayerPrefs.SetInt("AccountAuthorizedIndicator", 1);
    }
}