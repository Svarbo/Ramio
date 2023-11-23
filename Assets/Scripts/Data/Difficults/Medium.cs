using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Medium : IDifficult
{
    private const string Difficult = "Medium";

    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey("MediumDifficultAcceptLevels") == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt("MediumDifficultAcceptLevels");
    }

    public void IncreaseAcceptLevels(string sceneName)
    {
        string key = Difficult + sceneName;

        if (PlayerPrefs.HasKey(key) == false)
        {
            PlayerPrefs.SetString(key, key);
            PlayerPrefs.SetInt("MediumDifficultAcceptLevels", GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }
    }
    
    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt("MediumDifficultAcceptLevels", 1);
        PlayerPrefs.Save();
    }
}