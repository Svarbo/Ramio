using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class LevelsProgress : ScriptableObject
    {
        [SerializeField] private Easy _easy;

        [SerializeField] private List<Difficult> _difficultLevels = new List<Difficult>()
        {
            new Easy(),
            new Medium(),
            new Hard()
        };

        public Difficult GetDifficultLevel(Type difficultLevel)
        {
            foreach (Difficult difficult in _difficultLevels)
            {
                if (difficult.GetType() == difficultLevel)
                    return difficult;
            }

            throw new ArgumentException(nameof(difficultLevel));
        }

        #region MyRegion

        [Serializable]
        public class Difficult
        {
            [field: SerializeField] public int CountComplete { get; set; }
        }

        [Serializable]
        public class Easy : Difficult
        {
            public void ChangeSpawnPoint(string sceneName, Vector3 position) =>
                PlayerPrefs.SetString(sceneName, JsonUtility.ToJson(position));

            public Vector3 GetSpawnPoint(string sceneName)
            {
               if (PlayerPrefs.HasKey(sceneName) == false)
                   return default;

               string jsonVector = PlayerPrefs.GetString(sceneName);
               return JsonUtility.FromJson<Vector3>(jsonVector);
            }

            public void Save() =>
                PlayerPrefs.Save();
        }

        [Serializable]
        public class Medium : Difficult
        {
        }

        [Serializable]
        public class Hard : Difficult
        {
        }

        #endregion

    }

}