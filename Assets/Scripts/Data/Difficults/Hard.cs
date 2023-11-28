using System;
using UnityEngine;

[Serializable]
public class Hard : IDifficult
{
    private const string Difficult = "Hard";
    private const string CountTry = "CountTry";
    private const string HardDifficultKey = "HardDifficultAcceptLevels";

    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey(HardDifficultKey) == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt(HardDifficultKey);
    }

    public void IncreaseAcceptLevels(string sceneName)
    {
        PlayerPrefs.SetInt(HardDifficultKey, GetAcceptLevels() + 1);
        PlayerPrefs.Save();
    }

    public void IncreaseCountTry(string sceneName)
    {
        string key = CountTry + Difficult + sceneName;

        int countTry = GetCountTry(sceneName) + 1;
        PlayerPrefs.SetInt(key, countTry);
        PlayerPrefs.Save();
    }

    public int GetCountTry(string sceneName)
    {
        string key = CountTry + Difficult + sceneName;
        int countTry = PlayerPrefs.GetInt(key);

        return countTry;
    }

    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt(HardDifficultKey, 1);
        PlayerPrefs.Save();
    }
}