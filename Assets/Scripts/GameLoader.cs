using UnityEngine;
using IJunior.TypedScenes;

public class GameLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        MainMenu.Load();
    }

    public void LoadGame()
    {
        Game.Load();
    }
}
