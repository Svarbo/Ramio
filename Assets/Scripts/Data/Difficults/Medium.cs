using System;
using UnityEngine;

[Serializable]
public class Medium : IDifficult
{
    private const string Difficult = "Medium";
    private const string CountTry = "CountTry";
    private const string MediumDifficultKey = "MediumDifficultAcceptLevels";

    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey(MediumDifficultKey) == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt(MediumDifficultKey);
    }

    public void IncreaseAcceptLevels(string sceneName)
    {
        PlayerPrefs.SetInt(MediumDifficultKey, GetAcceptLevels() + 1);
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
        PlayerPrefs.SetInt(MediumDifficultKey, 1);
        PlayerPrefs.Save();
    }
}