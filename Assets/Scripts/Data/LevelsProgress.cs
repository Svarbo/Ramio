using ConstantValues;
using Data.Difficults;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
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

        private List<IDifficult> _difficults = new List<IDifficult>()
        {
            new Easy(),
            new Medium(),
            new Hard(),
        };

        public Type GetStartDifficult()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsNames.StartGameDifficult) == false)
                return typeof(Medium);

            string typeDifficult = PlayerPrefs.GetString(PlayerPrefsNames.StartGameDifficult);

            Type difficult = Type.GetType(typeDifficult);

            GetDifficultByType(difficult);

            return difficult;
        }

        public void SetStartDifficult(string typeDifficult)
        {
            IDifficult difficult = GetDifficultByType(Type.GetType(typeDifficult));
            PlayerPrefs.SetString(PlayerPrefsNames.StartGameDifficult, difficult.ToString());
            PlayerPrefs.Save();
        }

        public IDifficult GetDifficultByType(Type type)
        {
            foreach (IDifficult difficult in _difficults)
            {
                if (difficult.GetType() == type)
                    return difficult;
            }

            throw new InvalidOperationException(nameof(type));
        }

        public void ClearAllProgress() =>
            _difficults.ForEach(difficult => difficult.ClearProgress());
    }
}