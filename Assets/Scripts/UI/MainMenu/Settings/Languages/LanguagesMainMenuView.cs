using UI.MainMenu.Settings.Languages.Views;
using UnityEngine;

namespace UI.MainMenu.Settings.Languages
{
    public class LanguagesMainMenuView : MonoBehaviour
    {
        [field: SerializeField] public LanguageView LanguageRUView { get; }
        [field: SerializeField] public LanguageView LanguageENView { get; }
        [field: SerializeField] public LanguageView LanguageTRView { get; }
    }
}