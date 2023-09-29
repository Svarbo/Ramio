using UnityEngine;
using System.Collections;
using Agava.YandexGames;

public class SDKInstantiator : MonoBehaviour
{
    [SerializeField] private Sounds _sounds;
    [SerializeField] private LanguageDefiner _languageDefiner;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        if (PlayerAccount.IsAuthorized == false)
            PlayerAccount.StartAuthorizationPolling(1500);

        _sounds.SetVolumeValues();
        _languageDefiner.TryDefineLanguage();
    }
}
