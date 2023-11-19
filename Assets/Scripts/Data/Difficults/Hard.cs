using System;
using UnityEngine;

[Serializable]
public class Hard : IDifficult
{
    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey("HardDifficultAcceptLevels") == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt("HardDifficultAcceptLevels");
    }

    public void IncreaseAcceptLevels()
    {
        PlayerPrefs.SetInt("HardDifficultAcceptLevels", GetAcceptLevels() + 1);
        PlayerPrefs.Save();
    }

    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt("HardDifficultAcceptLevels", 1);
        PlayerPrefs.Save();
    }
}