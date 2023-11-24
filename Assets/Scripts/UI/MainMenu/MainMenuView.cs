using UnityEngine;

public class MainMenuView : MonoBehaviour
{
    [field: SerializeField] public LevelMenuView LevelMenuView { get; private set; }
    [field: SerializeField] public SettingsView SettingsView { get; private set; }
    [field: SerializeField] public UserInfo UserInfo { get; private set; }
    
}