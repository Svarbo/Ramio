using ConstantValues;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.Difficults
{
    [Serializable]
    public class Easy : IDifficult
    {
        public void ChangeSpawnPoint(string sceneName, SceneSpawnPoint sceneSpawnPoint)
        {
            string key = DifficultNames.EasySpawnPoint + sceneName;

            PlayerPrefs.SetString(key, JsonUtility.ToJson(sceneSpawnPoint));
            PlayerPrefs.Save();
        }

        public int GetAcceptLevels()
        {
            if (PlayerPrefs.HasKey(DifficultNames.EasyDifficultKey) == false)
                SetStartAcceptLevels();

            return PlayerPrefs.GetInt(DifficultNames.EasyDifficultKey);
        }

        public void IncreaseAcceptLevels()
        {
            PlayerPrefs.SetInt(DifficultNames.EasyDifficultKey, GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }

        public SceneSpawnPoint GetSpawnPoint(string sceneName)
        {
            string key = DifficultNames.EasySpawnPoint + sceneName;

            if (PlayerPrefs.HasKey(key) == false)
                return default;

            string sceneSpawnPoint = PlayerPrefs.GetString(key);

            return JsonUtility.FromJson<SceneSpawnPoint>(sceneSpawnPoint);
        }

        public void IncreaseCountTry(string sceneName)
        {
            string key = DifficultNames.CountTry + DifficultNames.EasyDifficult + sceneName;

            int countTry = GetCountTryBySceneName(sceneName) + 1;
            PlayerPrefs.SetInt(key, countTry);
            PlayerPrefs.Save();
        }

        public int GetCountTryBySceneName(string sceneName)
        {
            string key = DifficultNames.CountTry + DifficultNames.EasyDifficult + sceneName;
            int countTry = PlayerPrefs.GetInt(key, 0);

            return countTry;
        }

        public int GetAllCountTry()
        {
            List<Levels> levelsNames = Enum.GetValues(typeof(Levels)).Cast<Levels>().ToList();
            int allTry = 0;

            foreach (Levels levelName in levelsNames)
                allTry += GetCountTryBySceneName(levelName.ToString());

            return allTry;
        }

        public void ClearProgress()
        {
            List<Levels> levelsNames = Enum.GetValues(typeof(Levels)).Cast<Levels>().ToList();

            foreach (Levels levelName in levelsNames)
            {
                if (PlayerPrefs.HasKey(DifficultNames.CountTry + DifficultNames.EasyDifficult + levelName))
                    PlayerPrefs.DeleteKey(DifficultNames.CountTry + DifficultNames.EasyDifficult + levelName);

                if (PlayerPrefs.HasKey(DifficultNames.EasySpawnPoint + levelName))
                    PlayerPrefs.DeleteKey(DifficultNames.EasySpawnPoint + levelName);
            }

            PlayerPrefs.DeleteKey(DifficultNames.EasyDifficultKey);
        }

        private void SetStartAcceptLevels()
        {
            PlayerPrefs.SetInt(DifficultNames.EasyDifficultKey, 1);
            PlayerPrefs.Save();
        }
    }
}