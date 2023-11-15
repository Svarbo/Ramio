using UI.MainMenu.Settings.Audio;
using UI.MainMenu.Settings.Languages;
using UnityEngine;

namespace UI.MainMenu.Settings
{
    public class SettingsView : MonoBehaviour
    {
        [field: SerializeField] public AudioMenuView AudioMenuView { get; private set; }
        [field: SerializeField] public LanguagesMainMenuView LanguagesMainMenuView { get; private set; }
    }
}