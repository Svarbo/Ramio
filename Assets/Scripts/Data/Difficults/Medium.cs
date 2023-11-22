using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Medium : IDifficult
{
    private List<string> _scenes = new List<string>();

    public int GetAcceptLevels()
    {
        if (PlayerPrefs.HasKey("MediumDifficultAcceptLevels") == false)
            SetStartAcceptLevels();
        return PlayerPrefs.GetInt("MediumDifficultAcceptLevels");
    }

    public void IncreaseAcceptLevels()
    {
        if (TryAddScene())
        {
            PlayerPrefs.SetInt("MediumDifficultAcceptLevels", GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }
    }

    private bool TryAddScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (PlayerPrefs.HasKey("MediumSceneComplited") == false)
        {
            PlayerPrefs.SetString("MediumSceneComplited", JsonUtility.ToJson(_scenes));
            PlayerPrefs.Save();
            return false;
        }

        _scenes = JsonUtility.FromJson<List<string>>(PlayerPrefs.GetString("MediumSceneComplited"));

        if (_scenes.Contains(sceneName) == false)
        {
            _scenes.Add(sceneName);
            PlayerPrefs.SetString("MediumSceneComplited", JsonUtility.ToJson(_scenes));
            PlayerPrefs.Save();
            return true;
        }
        
        return false;
    }

    private void SetStartAcceptLevels()
    {
        PlayerPrefs.SetInt("MediumDifficultAcceptLevels", 1);
        PlayerPrefs.Save();
    }
}