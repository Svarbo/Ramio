using ConstantValues;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Localization
{
    [RequireComponent(typeof(TMP_Text))]
    public class Localizator : MonoBehaviour
    {
        [SerializeField] private List<string> _translations = new List<string>();

        private TMP_Text _text;
        private int _languageIndex;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();

            SetNeededText();
        }

        private void SetNeededText()
        {
            _languageIndex = PlayerPrefs.GetInt(PlayerPrefsNames.LanguageIndex);
            _text.text = _translations[_languageIndex];
        }
    }
}