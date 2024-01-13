using Agava.YandexGames;
using ConstantValues;
using UnityEngine;

namespace Localization
{
    public class LanguageDefiner
    {
        public void DefineLanguage()
        {
            string languageDesignation = "ru"; 
            //YandexGamesSdk.Environment.i18n.lang;

            if (languageDesignation == LanguageInfo.RussianDesignation || languageDesignation == LanguageInfo.BelarusianDesignation || languageDesignation == LanguageInfo.KazakhDesignation || languageDesignation == LanguageInfo.UkrainianDesignation || languageDesignation == LanguageInfo.UzbekDesignation)
                PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, LanguageInfo.RussianLanguageIndex);
            else if (languageDesignation == LanguageInfo.TurkishDesignation)
                PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, LanguageInfo.TurkishLanguageIndex);
            else
                PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, LanguageInfo.EnglishLanguageIndex);

            PlayerPrefs.Save();
        }
    }
}