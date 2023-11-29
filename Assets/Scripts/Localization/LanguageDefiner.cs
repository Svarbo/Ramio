using Agava.YandexGames;
using UnityEngine;

namespace Localization
{
    public class LanguageDefiner : MonoBehaviour
    {
        private const int RussianLanguageIndex = 0;
        private const int EnglishLanguageIndex = 1;
        private const int TurkishLanguageIndex = 2;

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
                UnityEngine.PlayerPrefs.SetInt("LanguageIndex", RussianLanguageIndex);
            else if (languageDesignation == "tr")
                UnityEngine.PlayerPrefs.SetInt("LanguageIndex", TurkishLanguageIndex);
            else
                UnityEngine.PlayerPrefs.SetInt("LanguageIndex", EnglishLanguageIndex);

            UnityEngine.PlayerPrefs.Save();
        }
    }
}