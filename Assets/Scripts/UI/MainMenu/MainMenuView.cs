using UI.MainMenu.LevelMenu;
using UI.MainMenu.Settings;
using UnityEngine;

namespace UI.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [field: SerializeField] public LevelMenuView LevelMenuView { get; private set; }
        [field: SerializeField] public SettingsView SettingsView { get; private set; }
    }
}