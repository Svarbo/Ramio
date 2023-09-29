using UnityEngine;
using Agava.YandexGames;

public class LanguageDefiner : MonoBehaviour
{
    public bool TryDefineLanguage()
    {
        bool languageWasChanged = UnityEngine.PlayerPrefs.GetInt("LanguageWasChanged") == 1;

        if (languageWasChanged != true)
            DefineLanguage();

        return !languageWasChanged;
    }

    private void DefineLanguage()
    {
        string languageDesignation = YandexGamesSdk.Environment.i18n.lang;

        if (languageDesignation == "ru" || languageDesignation == "be" || languageDesignation == "kk" || languageDesignation == "uk" || languageDesignation == "uz")
        {
            UnityEngine.PlayerPrefs.SetInt("LanguageIndex", 0);
        }
        else if (languageDesignation == "tr")
        {
            UnityEngine.PlayerPrefs.SetInt("LanguageIndex", 2);
        }
        else
        {
            UnityEngine.PlayerPrefs.SetInt("LanguageIndex", 1);
        }

        UnityEngine.PlayerPrefs.Save();
    }
}