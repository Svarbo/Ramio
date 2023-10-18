using System;
using System.Collections;
using UnityEngine;
using IJunior.TypedScenes;
using UI;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private PlayerDance _playerDance;
    [SerializeField] private Curtain _curtain;

    private void Start()
    {
        _playerDance?.PlayDance();
    }

    public void LoadMainMenu()
    {
        MainMenu.Load();
    }

    public void LoadLevel(int levelNumber)
    {
        _curtain.Show(() => SceneManager.LoadScene($"Level{levelNumber}"));
    }

    public void RestartCurrentLevel()
    {

    }
}