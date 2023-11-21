using System;
using UnityEngine;

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

    public IDifficult GetDifficultByType(Type type)
    {
        if(type == typeof(Easy))
            return GetEasyDifficult();
        else if (type == typeof(Medium))
            return GetMediumDifficult();
        else if (type == typeof(Hard))
            return GetHardDifficult();

        throw new InvalidOperationException(nameof(type));
    }
    
    public Easy GetEasyDifficult()
    {
        if (PlayerPrefs.HasKey("EasyDifficult") == false)
        {
            PlayerPrefs.SetString("EasyDifficult", JsonUtility.ToJson(new Easy()));
            PlayerPrefs.Save();
        }

        string json = PlayerPrefs.GetString("EasyDifficult");
        Debug.Log(json);

        Easy mediumDifficult = JsonUtility.FromJson<Easy>(json);
        Debug.Log(mediumDifficult);
        return mediumDifficult;
    }
    
    public Medium GetMediumDifficult()
    {
        if (PlayerPrefs.HasKey("MediumDifficult") == false)
        {
            PlayerPrefs.SetString("MediumDifficult", JsonUtility.ToJson(new Medium()));
            PlayerPrefs.Save();
        }

        string json = PlayerPrefs.GetString("MediumDifficult");
        Debug.Log(json);

        Medium mediumDifficult = JsonUtility.FromJson<Medium>(json);
        Debug.Log(mediumDifficult);
        return mediumDifficult;
    }

    public Hard GetHardDifficult()
    {
        if (PlayerPrefs.HasKey("HardDifficult") == false)
            PlayerPrefs.SetString("HardDifficult", JsonUtility.ToJson(new Hard()));

        string json = PlayerPrefs.GetString("HardDifficult");
        Debug.Log(json);

        Hard hardDifficult = JsonUtility.FromJson<Hard>(json);
        Debug.Log(hardDifficult);
        return hardDifficult;
    }
}