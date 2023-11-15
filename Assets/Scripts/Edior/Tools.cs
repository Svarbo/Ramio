using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Edior
{
    public class Tools : MonoBehaviour
    {
        [MenuItem("Tools/Clear Player Prefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}