using Agava.YandexGames;
using ConstantValues;

namespace Localization
{
    public class LanguageDefiner
    {
        private const int RussianLanguageIndex = 0;
        private const int EnglishLanguageIndex = 1;
        private const int TurkishLanguageIndex = 2;

        public bool TryDefineLanguage()
        {
            bool languageWasChanged = UnityEngine.PlayerPrefs.GetInt(PlayerPrefsNames.LanguageWasChanged) == 1;

            if (languageWasChanged != true)
                DefineLanguage();

            return !languageWasChanged;
        }

        public void DefineLanguage()
        {
            string languageDesignation = YandexGamesSdk.Environment.i18n.lang;

            if (languageDesignation == "ru" || languageDesignation == "be" || languageDesignation == "kk" || languageDesignation == "uk" || languageDesignation == "uz")
                UnityEngine.PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, RussianLanguageIndex);
            else if (languageDesignation == "tr")
                UnityEngine.PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, TurkishLanguageIndex);
            else
                UnityEngine.PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, EnglishLanguageIndex);

            UnityEngine.PlayerPrefs.Save();
        }
    }
}