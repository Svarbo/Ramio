using System;
using UnityEngine;

[Serializable]
public class Easy : IDifficult
{
    public void ChangeSpawnPoint(string sceneName, Vector3 position) =>
        PlayerPrefs.SetString(sceneName, JsonUtility.ToJson(position));

    public Vector3 GetSpawnPoint(string sceneName)
    {
        if (PlayerPrefs.HasKey(sceneName) == false)
            return default;

        string jsonVector = PlayerPrefs.GetString(sceneName);
        return JsonUtility.FromJson<Vector3>(jsonVector);
    }

    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey("EasyDifficultAcceptLevels") == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt("EasyDifficultAcceptLevels");
    }

    public void IncreaseAcceptLevels()
    {
        PlayerPrefs.SetInt("EasyDifficultAcceptLevels", GetAcceptLevels() + 1);
        PlayerPrefs.Save();
    }

    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt("EasyDifficultAcceptLevels", 1);
        PlayerPrefs.Save();
    }
}