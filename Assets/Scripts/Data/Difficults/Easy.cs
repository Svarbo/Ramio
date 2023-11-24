using System;
using UnityEngine;

[Serializable]
public class Easy : IDifficult
{
    private const string Difficult = "Easy";
    private const string SpawnPoint = "EasySpawnPoint";
    private const string EasyDifficultKey = "EasyDifficultAcceptLevels";

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
        if (PlayerPrefs.HasKey(EasyDifficultKey) == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt(EasyDifficultKey);
    }

    public void IncreaseAcceptLevels(string sceneName)
    {
        string key = Difficult + sceneName;

        if (PlayerPrefs.HasKey(key) == false)
        {
            PlayerPrefs.SetString(key, key);
            PlayerPrefs.SetInt(EasyDifficultKey, GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }
    }

    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt(EasyDifficultKey, 1);
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