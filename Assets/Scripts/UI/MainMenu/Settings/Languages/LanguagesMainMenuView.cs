using UI.MainMenu.Settings.Languages.Views;
using UnityEngine;

namespace UI.MainMenu.Settings.Languages
{
    public class LanguagesMainMenuView : MonoBehaviour
    {
        [field: SerializeField] public LanguageToggleView LanguageToggleRuView { get; }
        [field: SerializeField] public LanguageToggleView LanguageToggleEnView { get; }
        [field: SerializeField] public LanguageToggleView LanguageToggleTRView { get; }
    }
}