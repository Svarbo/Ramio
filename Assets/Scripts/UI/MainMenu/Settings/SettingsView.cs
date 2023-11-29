using Localization;
using UI.MainMenu.Settings.Audio;
using UI.MainMenu.Settings.Languages;
using UnityEngine;

public class SettingsView : MonoBehaviour
{
    [field: SerializeField] public AudioMenuView AudioMenuView { get; private set; }
    [field: SerializeField] public LanguageChanger LanguageChanger { get; private set; }
}