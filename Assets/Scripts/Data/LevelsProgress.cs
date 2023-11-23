using System;
using System.Collections.Generic;

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