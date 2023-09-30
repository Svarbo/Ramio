using UnityEngine;

public class Reseter : MonoBehaviour
{
    private void Start()
    {
        ResetAll();
    }

    private void ResetAll()
    {
        int isFirstStart = PlayerPrefs.GetInt("IsFirstStart");

        if (isFirstStart != 1)
        {
            PlayerPrefs.DeleteAll();

            PlayerPrefs.SetInt("OpenLevelsNumber", 1);
            PlayerPrefs.SetInt("CompletedLevelsCount", 0);
            PlayerPrefs.SetFloat("Volume", 0.7f);
            PlayerPrefs.SetInt("AttemptCount", 0);
            PlayerPrefs.SetInt("PlayerScore", 0);
            PlayerPrefs.SetInt("LanguageWasChanged", 0);

            PlayerPrefs.SetInt("IsFirstStart", 1);

            PlayerPrefs.Save();

            Debug.Log("Удалил все");
        }
    }

    public void ResetAllPrefs()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("OpenLevelsNumber", 1);
        PlayerPrefs.SetInt("CompletedLevelsCount", 1);
        PlayerPrefs.SetFloat("Volume", 0.7f);
        PlayerPrefs.SetInt("AttemptCount", 0);
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.SetInt("LanguageIndex", 1);
        PlayerPrefs.SetInt("LanguageWasChanged", 0);
        PlayerPrefs.SetInt("AccountAuthorizedIndicator", 0);

        PlayerPrefs.Save();
    }
}