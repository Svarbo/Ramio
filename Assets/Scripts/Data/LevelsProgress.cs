using System;
using UnityEngine;

public class LevelsProgress
{
    private static LevelsProgress _instance;

    public static LevelsProgress Instance
    {
        get
        {
            if (_instance == null)
                _instance = new LevelsProgress();

            return _instance;
        }
    }

    public IDifficult GetDifficultByType(Type type)
    {
        if (type == typeof(Medium))
            return GetMediumDifficult();
        else if (type == typeof(Hard))
            return GetHardDifficult();

        throw new InvalidOperationException(nameof(type));
    } 
    public Medium GetMediumDifficult()
    {
        if (PlayerPrefs.HasKey("MediumDifficult") == false)
        {
            PlayerPrefs.SetString("MediumDifficult", JsonUtility.ToJson(new Medium()));
            PlayerPrefs.Save();
        }

        string json = PlayerPrefs.GetString("MediumDifficult");
        Debug.Log(json);

        Medium mediumDifficult = JsonUtility.FromJson<Medium>(json);
        Debug.Log(mediumDifficult);
        return mediumDifficult;
    }

    public Hard GetHardDifficult()
    {
        if (PlayerPrefs.HasKey("HardDifficult") == false)
            PlayerPrefs.SetString("HardDifficult", JsonUtility.ToJson(new Hard()));

        string json = PlayerPrefs.GetString("HardDifficult");
        Debug.Log(json);

        Hard hardDifficult = JsonUtility.FromJson<Hard>(json);
        Debug.Log(hardDifficult);
        return hardDifficult;
    }

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
}

public interface IDifficult
{
    public int GetAcceptLevels();

    public void IncreaseAcceptLevels();
}