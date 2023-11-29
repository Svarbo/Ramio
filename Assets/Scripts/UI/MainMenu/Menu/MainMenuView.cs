using UI.MainMenu.LevelMenu;
using UnityEngine;

namespace UI.MainMenu.Menu
{
    public class MainMenuView : MonoBehaviour
    {
        [field: SerializeField] public LevelMenuView LevelMenuView { get; private set; }
        [field: SerializeField] public SettingsView SettingsView { get; private set; }
    }
}