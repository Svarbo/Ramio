using System;
using UnityEngine;

[Serializable]
public class Hard : IDifficult
{
    private const string Difficult = "Hard";
    private const string MediumDifficultKey = "HardDifficultAcceptLevels";
    
    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey(MediumDifficultKey) == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt(MediumDifficultKey);
    }

    public void IncreaseAcceptLevels(string sceneName)
    {
        string key = Difficult + sceneName;

        if (PlayerPrefs.HasKey(key) == false)
        {
            PlayerPrefs.SetString(key, key);
            PlayerPrefs.SetInt(MediumDifficultKey, GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }
    }
    
    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt(MediumDifficultKey, 1);
        PlayerPrefs.Save();
    }
}