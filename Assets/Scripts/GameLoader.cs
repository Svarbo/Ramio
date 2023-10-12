using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        MainMenu.Load();
    }

    public void LoadGame(int levelNumber)
    {
        SceneManager.LoadScene($"Level{levelNumber}");
    }
}