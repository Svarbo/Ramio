using System;
using System.Collections.Generic;
using System.Linq;
using ConstantValues;
using UnityEngine;

namespace Data.Difficults
{
    [Serializable]
    public class Medium : IDifficult
    {
        public int GetAcceptLevels()
        {
            if (PlayerPrefs.HasKey(DifficultNames.MediumDifficultKey) == false)
                SetStartAcceptLevels();
            return PlayerPrefs.GetInt(DifficultNames.MediumDifficultKey);
        }

        public void IncreaseAcceptLevels()
        {
            PlayerPrefs.SetInt(DifficultNames.MediumDifficultKey, GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }

        public void IncreaseCountTry(string sceneName)
        {
            string key = DifficultNames.CountTry + DifficultNames.MediumDifficult + sceneName;

            int countTry = GetCountTryBySceneName(sceneName) + 1;
            PlayerPrefs.SetInt(key, countTry);
            PlayerPrefs.Save();
        }

        public int GetAllCountTry()
        {
            List<Levels> levelsNames = Enum.GetValues(typeof(Levels)).Cast<Levels>().ToList();
            int allTry = 0;

            foreach (Levels levelName in levelsNames)
                allTry += GetCountTryBySceneName(levelName.ToString());

            return allTry;
        }

        public int GetCountTryBySceneName(string sceneName)
        {
            string key = DifficultNames.CountTry + DifficultNames.MediumDifficult + sceneName;
            int countTry = PlayerPrefs.GetInt(key);

            return countTry;
        }

        public void ClearProgress()
        {
            List<Levels> levelsNames = Enum.GetValues(typeof(Levels)).Cast<Levels>().ToList();

            foreach (Levels levelName in levelsNames)
            {
                if (PlayerPrefs.HasKey(DifficultNames.CountTry + DifficultNames.MediumDifficult + levelName))
                    PlayerPrefs.DeleteKey(DifficultNames.CountTry + DifficultNames.MediumDifficult + levelName);
            }

            PlayerPrefs.DeleteKey(DifficultNames.MediumDifficultKey);
        }

        private void SetStartAcceptLevels()
        {
            PlayerPrefs.SetInt(DifficultNames.MediumDifficultKey, 1);
            PlayerPrefs.Save();
        }
    }
}