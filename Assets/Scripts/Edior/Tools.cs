using UnityEditor;
using UnityEngine;

public class Tools : MonoBehaviour
{
    [MenuItem("Tools/Clear Player Prefs")]
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    [MenuItem("Tools/Clear Medium Difficult Saves")]
    public static void ClearMediumDifficult()
    {
        PlayerPrefs.DeleteKey("MediumDifficult");
        PlayerPrefs.DeleteKey("MediumDifficultAcceptLevels");
        PlayerPrefs.Save();
    }
}