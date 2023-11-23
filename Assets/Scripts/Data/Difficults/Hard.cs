using System;
using UnityEngine;

[Serializable]
public class Hard : IDifficult
{
    private const string Difficult = "Hard";

    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey("HardDifficultAcceptLevels") == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt("HardDifficultAcceptLevels");
    }

    public void IncreaseAcceptLevels(string sceneName)
    {
        string key = Difficult + sceneName;

        if (PlayerPrefs.HasKey(key) == false)
        {
            PlayerPrefs.SetString(key, key);
            PlayerPrefs.SetInt("HardDifficultAcceptLevels", GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }
    }
    
    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt("HardDifficultAcceptLevels", 1);
        PlayerPrefs.Save();
    }
}