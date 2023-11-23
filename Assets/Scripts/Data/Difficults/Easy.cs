using System;
using UnityEngine;

[Serializable]
public class Easy : IDifficult
{
    private const string Difficult = "Easy";
    private const string SpawnPoint = "EasySpawnPoint";

    public void ChangeSpawnPoint(string sceneName, SceneSpawnPoint sceneSpawnPoint)
    {
        string key = SpawnPoint + sceneName;

        PlayerPrefs.SetString(key, JsonUtility.ToJson(sceneSpawnPoint));
        PlayerPrefs.Save();
    }

    public SceneSpawnPoint GetSpawnPoint(string sceneName)
    {
        string key = SpawnPoint + sceneName;

        if (PlayerPrefs.HasKey(key) == false)
            return default;

        string jsonVector = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<SceneSpawnPoint>(jsonVector);
    }

    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey("EasyDifficultAcceptLevels") == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt("EasyDifficultAcceptLevels");
    }

    public void IncreaseAcceptLevels(string sceneName)
    {
        string key = Difficult + sceneName;

        if (PlayerPrefs.HasKey(key) == false)
        {
            PlayerPrefs.SetString(key, key);
            PlayerPrefs.SetInt("EasyDifficultAcceptLevels", GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }
    }

    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt("EasyDifficultAcceptLevels", 1);
        PlayerPrefs.Save();
    }
}

[Serializable]
public struct SceneSpawnPoint
{
    public int Id;
    public Vector3 Position;

    public SceneSpawnPoint(int id, Vector3 position)
    {
        Id = id;
        Position = position;
    }
}