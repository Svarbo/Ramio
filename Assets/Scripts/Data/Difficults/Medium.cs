using System;
using UnityEngine;

[Serializable]
public class Medium : IDifficult
{
    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey("MediumDifficultAcceptLevels") == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt("MediumDifficultAcceptLevels");
    }

    public void IncreaseAcceptLevels()
    {
        PlayerPrefs.SetInt("MediumDifficultAcceptLevels", GetAcceptLevels() + 1);
        PlayerPrefs.Save();
    }

    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt("MediumDifficultAcceptLevels", 1);
        PlayerPrefs.Save();
    }
}