using System;
using UnityEngine;

[Serializable]
public class Easy
{
    [SerializeField] private int _countComplete;

    public void ChangeSpawnPoint(string sceneName, Vector3 position) =>
        PlayerPrefs.SetString(sceneName, JsonUtility.ToJson(position));

    public Vector3 GetSpawnPoint(string sceneName)
    {
        if (PlayerPrefs.HasKey(sceneName) == false)
            return default;

        string jsonVector = PlayerPrefs.GetString(sceneName);
        return JsonUtility.FromJson<Vector3>(jsonVector);
    }

    public void SetAcceptLevelEasyDifficult(int count)
    {
        PlayerPrefs.SetInt("LevelEasy", count);
    }

}