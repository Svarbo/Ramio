using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class Tools : MonoBehaviour
    {
        // TODO Закоментировать
        [MenuItem("Tools/Clear All Player Prefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        //[MenuItem("Tools/Clear Easy IDifficult Saves")]
        //public static void ClearEasyDifficult()
        //{
        //    PlayerPrefs.DeleteKey("EasyDifficult");
        //    PlayerPrefs.DeleteKey("EasyDifficultAcceptLevels");
        //    PlayerPrefs.Save();
        //}

        //[MenuItem("Tools/Clear Medium IDifficult Saves")]
        //public static void ClearMediumDifficult()
        //{
        //    PlayerPrefs.DeleteKey("MediumDifficult");
        //    PlayerPrefs.DeleteKey("MediumDifficultAcceptLevels");
        //    PlayerPrefs.Save();
        //}

        //[MenuItem("Tools/Clear Hard IDifficult Saves")]
        //public static void ClearHardDifficult()
        //{
        //    PlayerPrefs.DeleteKey("HardDifficult");
        //    PlayerPrefs.DeleteKey("HardDifficultAcceptLevels");
        //    PlayerPrefs.Save();
        //}
    }
}