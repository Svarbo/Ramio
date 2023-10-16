using Agava.YandexGames;
using Configs;

public class LanguageDefiner
{
    public bool TryDefineLanguage()
    {
        bool languageWasChanged = PlayerPrefs.GetInt("LanguageWasChanged") == 1;

        if (languageWasChanged != true)
            DefineLanguage();

        return !languageWasChanged;
    }

    private void DefineLanguage()
    {
        string languageDesignation = YandexGamesSdk.Environment.i18n.lang;

        if (
            languageDesignation == LanguageCode.Russian 
            || languageDesignation == LanguageCode.Belarus 
            || languageDesignation == LanguageCode.Kaza 
            || languageDesignation == LanguageCode.Ukrainian 
            || languageDesignation == LanguageCode.Uzbeck
            )
        {
            PlayerPrefs.SetInt("LanguageIndex", 0);
        }
        else if (languageDesignation == LanguageCode.Turkish)
        {
            PlayerPrefs.SetInt("LanguageIndex", 2);
        }
        else
        {
            PlayerPrefs.SetInt("LanguageIndex", 1);
        }

        PlayerPrefs.Save();
    }
}