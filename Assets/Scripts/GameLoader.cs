using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        MainMenu.Load();
    }

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene($"Level{levelNumber}");
    }

    public void RestartCurrentLevel()
    {

    }
}