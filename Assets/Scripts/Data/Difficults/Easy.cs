using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Easy : IDifficult
{
    private List<string> _scenes = new List<string>();

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
        if (TryAddScene())
        {
            PlayerPrefs.SetInt("EasyDifficultAcceptLevels", GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }
    }

    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt("EasyDifficultAcceptLevels", 1);
        PlayerPrefs.Save();
    }
    
    private bool TryAddScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (PlayerPrefs.HasKey("EasySceneComplited") == false)
        {
            PlayerPrefs.SetString("EasySceneComplited", JsonUtility.ToJson(_scenes));
            PlayerPrefs.Save();
            return false;
        }

        _scenes = JsonUtility.FromJson<List<string>>(PlayerPrefs.GetString("EasySceneComplited"));

        if (_scenes.Contains(sceneName) == false)
        {
            _scenes.Add(sceneName);
            PlayerPrefs.SetString("EasySceneComplited", JsonUtility.ToJson(_scenes));
            PlayerPrefs.Save();
            return true;
        }
        
        return false;
    }
}