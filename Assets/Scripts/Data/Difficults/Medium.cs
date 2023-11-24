using System;
using UnityEngine;

[Serializable]
public class Medium : IDifficult
{
    private const string Difficult = "Medium";
    private const string Orange = "Orange";
    private const string MediumDifficultKey = "MediumDifficultAcceptLevels";

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

    public void SetOrangesCount(string sceneName, int score)
    {
        string key = Difficult + Orange + sceneName;

        if (PlayerPrefs.GetInt(key) > score)
            return;

        PlayerPrefs.SetInt(key, score);
        PlayerPrefs.Save();
    }


    public void ResetOrangesCount(string sceneName)
    {
        string key = Difficult + Orange + sceneName;
        PlayerPrefs.SetInt(key, 0);
        PlayerPrefs.Save();
    }

    public int GetOrangesCount(string sceneName)
    {
        string key = Difficult + Orange + sceneName;
        return PlayerPrefs.GetInt(key);
    }

    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt(MediumDifficultKey, 1);
        PlayerPrefs.Save();
    }
}