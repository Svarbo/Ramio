using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.Difficults
{
    [Serializable]
    public class Medium : IDifficult
    {
        private const string Difficult = "Medium";
        private const string CountTry = "CountTry";
        private const string MediumDifficultKey = "MediumDifficultAcceptLevels";

        public int GetAcceptLevels()
        {
            if (PlayerPrefs.HasKey(MediumDifficultKey) == false)
                SetStartAcceptLevels();
            return PlayerPrefs.GetInt(MediumDifficultKey);
        }

        public void IncreaseAcceptLevels()
        {
            PlayerPrefs.SetInt(MediumDifficultKey, GetAcceptLevels() + 1);
            PlayerPrefs.Save();
        }

        public void IncreaseCountTry(string sceneName)
        {
            string key = CountTry + Difficult + sceneName;

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
            string key = CountTry + Difficult + sceneName;
            int countTry = PlayerPrefs.GetInt(key);

            return countTry;
        }
        
        public void ClearProgress()
        {
            List<Levels> levelsNames = Enum.GetValues(typeof(Levels)).Cast<Levels>().ToList();

            foreach (Levels levelName in levelsNames)
            {
                if (PlayerPrefs.HasKey(CountTry + Difficult + levelName))
                    PlayerPrefs.DeleteKey(CountTry + Difficult + levelName);
            }

            PlayerPrefs.DeleteKey(MediumDifficultKey);
        }


        private void SetStartAcceptLevels()
        {
            PlayerPrefs.SetInt(MediumDifficultKey, 1);
            PlayerPrefs.Save();
        }
    }
}