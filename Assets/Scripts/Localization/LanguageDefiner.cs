using Agava.YandexGames;
using ConstantValues;
using UnityEngine;

namespace Localization
{
    public class LanguageDefiner
    {
        private const int RussianLanguageIndex = 0;
        private const int EnglishLanguageIndex = 1;
        private const int TurkishLanguageIndex = 2;

        public bool TryDefineLanguage()
        {
            bool languageWasChanged = PlayerPrefs.GetInt(PlayerPrefsNames.LanguageWasChanged) == 1;

            if (languageWasChanged != true)
                DefineLanguage();

            return !languageWasChanged;
        }

        public void DefineLanguage()
        {
            string languageDesignation = YandexGamesSdk.Environment.i18n.lang;

            if (languageDesignation == "ru" || languageDesignation == "be" || languageDesignation == "kk" || languageDesignation == "uk" || languageDesignation == "uz")
                PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, RussianLanguageIndex);
            else if (languageDesignation == "tr")
                PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, TurkishLanguageIndex);
            else
                PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, EnglishLanguageIndex);

            PlayerPrefs.Save();
        }
    }
}