using System;
using System.Collections.Generic;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.PlayerPrefs;

[Serializable]
public class LevelsProgress
{
    private const string StartGameDifficult = "StartDifficult";
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

    public Type StartDifficult()
    {
        if (PlayerPrefs.HasKey(StartGameDifficult) == false)
            return typeof(Medium);

        return JsonUtility.FromJson<Type>(PlayerPrefs.GetString(StartGameDifficult));
    }

    public void SetStartDifficult(Type type)
    {
        PlayerPrefs.SetString(StartGameDifficult, JsonUtility.ToJson(type));
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
}