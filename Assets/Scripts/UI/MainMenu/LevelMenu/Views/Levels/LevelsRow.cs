using System.Collections.Generic;
using UnityEngine;

public class LevelsRow : MonoBehaviour
{
    [SerializeField] private List<LevelChooser> _levelChoosers;

    public IReadOnlyList<LevelChooser> LevelChoosers => _levelChoosers;

    public void ShowLevelChoosers(int count)
    {
        for (int i = 0; i < count; i++)
            _levelChoosers[i].Show();
    }
}