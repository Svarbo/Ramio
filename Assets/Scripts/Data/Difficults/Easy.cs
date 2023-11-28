using Assets.Scripts.Data.Difficults;
using System;
using UnityEngine;

namespace Data.Difficults
{
    [Serializable]
    public class Easy : IDifficult
    {
        private const string Difficult = "Easy";
        private const string CountTry = "CountTry";
        private const string SpawnPoint = "EasySpawnPoint";
        private const string EasyDifficultKey = "EasyDifficultAcceptLevels";

        public void ChangeSpawnPoint(string sceneName, SceneSpawnPoint sceneSpawnPoint)
        {
            string key = SpawnPoint + sceneName;

            PlayerPrefs.SetString(key, JsonUtility.ToJson(sceneSpawnPoint));
            PlayerPrefs.Save();
        }

        public int GetAcceptLevels()
        {
            if (PlayerPrefs.HasKey(EasyDifficultKey) == false)
                SetStartAcceptLevels();
            return PlayerPrefs.GetInt(EasyDifficultKey);
        }

        public void IncreaseAcceptLevels(string sceneName)
        {
            PlayerPrefs.SetInt(EasyDifficultKey, GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }

        public SceneSpawnPoint GetSpawnPoint(string sceneName)
        {
            string key = SpawnPoint + sceneName;

            if (PlayerPrefs.HasKey(key) == false)
                return default;

            string sceneSpawnPoint = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<SceneSpawnPoint>(sceneSpawnPoint);
        }

        public void IncreaseCountTry(string sceneName)
        {
            string key = CountTry + Difficult + sceneName;

            int countTry = GetCountTry(sceneName) + 1;
            PlayerPrefs.SetInt(key, countTry);
            PlayerPrefs.Save();
        }

        public int GetCountTry(string sceneName)
        {
            string key = CountTry + Difficult + sceneName;
            int countTry = PlayerPrefs.GetInt(key);

            return countTry;
        }

        private void SetStartAcceptLevels()
        {
            PlayerPrefs.SetInt(EasyDifficultKey, 1);
            PlayerPrefs.Save();
        }
    }
}